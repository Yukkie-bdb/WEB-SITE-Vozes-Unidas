using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using WebSiteVozesUnidas.Models;
using WebSiteVozesUnidas.Data;
using WebSiteVozesUnidas.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Org.BouncyCastle.Crypto.Generators;

namespace WebSiteVozesUnidas.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly VozesDbContext _context;

        public UsuariosController(VozesDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var usuarios = _context.Usuario.ToList();
            return View(usuarios);
        }

        public IActionResult Register()
        {
            return View(new UsuarioViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario;

                if (usuarioViewModel.Tipo == UsuarioTipo.Empresa)
                {
                    usuario = new Empresa
                    {
                        IdUsuario = Guid.NewGuid(),
                        Nome = usuarioViewModel.Nome,
                        Email = usuarioViewModel.Email,
                        Senha = BCrypt.Net.BCrypt.HashPassword(usuarioViewModel.Senha),
                        Tipo = usuarioViewModel.Tipo,
                        Cnpj = usuarioViewModel.Cnpj,
                        Telefone = usuarioViewModel.Telefone,
                        Descricao = usuarioViewModel.Descricao
                    };
                }
                else
                {
                    usuario = new Candidato
                    {
                        IdUsuario = Guid.NewGuid(),
                        Nome = usuarioViewModel.Nome,
                        Email = usuarioViewModel.Email,
                        Senha = BCrypt.Net.BCrypt.HashPassword(usuarioViewModel.Senha),
                        Tipo = usuarioViewModel.Tipo,
                        Cpf = usuarioViewModel.Cpf
                    };
                }

                _context.Usuario.Add(usuario);
                await _context.SaveChangesAsync();

                // Fazer login automático após o registro
                await SignInUser(usuario);
                return RedirectToAction(nameof(Index));
            }

            return View(usuarioViewModel);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UsuarioViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _context.Usuario
                    .FirstOrDefaultAsync(u => u.Email == loginViewModel.Email);

                if (usuario != null && BCrypt.Net.BCrypt.Verify(loginViewModel.Senha, usuario.Senha))
                {
                    // Login bem-sucedido
                    await SignInUser(usuario);
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, "Email ou senha inválidos.");
            }

            return View(loginViewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }

        private async Task SignInUser(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim("UsuarioId", usuario.IdUsuario.ToString()),
                new Claim("UsuarioTipo", usuario.Tipo.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), authProperties);
        }

        public IActionResult Edit(Guid id)
        {
            var usuario = _context.Usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            var usuarioViewModel = new UsuarioViewModel
            {
                IdUsuario = usuario.IdUsuario,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha,
                Tipo = usuario.Tipo,
                Cnpj = (usuario as Empresa)?.Cnpj,
                Telefone = (usuario as Empresa)?.Telefone,
                Descricao = (usuario as Empresa)?.Descricao,
                Cpf = (usuario as Candidato)?.Cpf
            };

            return View(usuarioViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, UsuarioViewModel usuarioViewModel)
        {
            if (id != usuarioViewModel.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var usuario = _context.Usuario.Find(id);
                if (usuario == null)
                {
                    return NotFound();
                }

                if (usuarioViewModel.Tipo == UsuarioTipo.Empresa && usuario is Empresa empresa)
                {
                    empresa.Nome = usuarioViewModel.Nome;
                    empresa.Email = usuarioViewModel.Email;
                    empresa.Senha = BCrypt.Net.BCrypt.HashPassword(usuarioViewModel.Senha);
                    empresa.Cnpj = usuarioViewModel.Cnpj;
                    empresa.Telefone = usuarioViewModel.Telefone;
                    empresa.Descricao = usuarioViewModel.Descricao;
                }
                else if (usuarioViewModel.Tipo == UsuarioTipo.Candidato && usuario is Candidato candidato)
                {
                    candidato.Nome = usuarioViewModel.Nome;
                    candidato.Email = usuarioViewModel.Email;
                    candidato.Senha = BCrypt.Net.BCrypt.HashPassword(usuarioViewModel.Senha);
                    candidato.Cpf = usuarioViewModel.Cpf;
                }
                else
                {
                    ModelState.AddModelError("", "Tipo de usuário inválido.");
                    return View(usuarioViewModel);
                }

                _context.Update(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(usuarioViewModel);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = _context.Usuario.Find(id);

            var usuarioViewModel = new UsuarioViewModel
            {
                IdUsuario = usuario.IdUsuario,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha,
                Tipo = usuario.Tipo,
                Cnpj = (usuario as Empresa)?.Cnpj,
                Telefone = (usuario as Empresa)?.Telefone,
                Descricao = (usuario as Empresa)?.Descricao,
                Cpf = (usuario as Candidato)?.Cpf
            };

            if (usuarioViewModel == null)
            {
                return NotFound();
            }

            return View(usuarioViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var usuarioViewModel = await _context.Usuario.FindAsync(id);
            if (usuarioViewModel != null)
            {
                _context.Usuario.Remove(usuarioViewModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioViewModelExists(Guid id)
        {
            return _context.Usuario.Any(e => e.IdUsuario == id);
        }
    }
}
