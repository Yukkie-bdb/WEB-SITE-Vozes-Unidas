using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using WebSiteVozesUnidas.Models;
using WebSiteVozesUnidas.Data;
using WebSiteVozesUnidas.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Tls;
using Microsoft.AspNetCore.Identity;
using System.IO;

namespace WebSiteVozesUnidas.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly VozesDbContext _context;
        private string _caminho;

        public UsuariosController(VozesDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _caminho = hostEnvironment.WebRootPath;
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
        public async Task<IActionResult> Register(UsuarioViewModel usuarioViewModel, IFormFile imgUp)
        {


            if (ModelState.IsValid)
            {
                foreach (var item in _context.Usuario.ToList())
                {
                    if (usuarioViewModel.Email == item.Email)
                    {
                        ViewData["Mensagem"] = "Esse email já está cadastrado.";
                        return View(usuarioViewModel);
                    }
                }

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

                if (imgUp != null && imgUp.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_caminho, "img");

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + imgUp.FileName;

                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await imgUp.CopyToAsync(fileStream);
                    }
                    usuario.ImagemPerfil = uniqueFileName;
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
            if (!string.IsNullOrEmpty(loginViewModel.Email) && !string.IsNullOrEmpty(loginViewModel.Senha))
            {
                var usuario = await _context.Usuario
                    .FirstOrDefaultAsync(u => u.Email == loginViewModel.Email);

                if (usuario != null && BCrypt.Net.BCrypt.Verify(loginViewModel.Senha, usuario.Senha))
                {
                    await SignInUser(usuario);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["ErrorMessage"] = "Email ou senha inválidos.";
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Por favor, insira e-mail e senha.";


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
                new Claim("UsuarioTipo", usuario.Tipo.ToString()),
                new Claim("ImagemPerfil", usuario.ImagemPerfil.ToString()),

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
                ImagemPerfil = usuario.ImagemPerfil,
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
        public async Task<IActionResult> Edit(Guid id, UsuarioViewModel usuarioViewModel, IFormFile imgUp)
        {
            if (id != usuarioViewModel.IdUsuario)
            {
                return NotFound();
            }
            // Verifica se já existe uma imagem associada ao usuário
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            // Se houver uma ImagemPerfil existente, excluí-la
            if (!string.IsNullOrEmpty(usuario.ImagemPerfil))
            {
                string existingFilePath = Path.Combine(_caminho, "img", usuario.ImagemPerfil);
                if (System.IO.File.Exists(existingFilePath))
                {
                    System.IO.File.Delete(existingFilePath);
                }
            }
            // Se uma nova imagem foi carregada, salvar a nova imagem

            if (imgUp != null && imgUp.Length > 0)
            {
                string uploadsFolder = Path.Combine(_caminho, "img");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + imgUp.FileName;

                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imgUp.CopyToAsync(fileStream);
                }
                usuarioViewModel.ImagemPerfil = uniqueFileName;
            }


            // Atualiza as informações do usuário
            if (ModelState.IsValid)
            {
                if (usuarioViewModel.Tipo == UsuarioTipo.Empresa && usuario is Empresa empresa)
                {
                    empresa.Nome = usuarioViewModel.Nome;
                    empresa.Email = usuarioViewModel.Email;
                    empresa.Senha = BCrypt.Net.BCrypt.HashPassword(usuarioViewModel.Senha);
                    empresa.ImagemPerfil = usuarioViewModel.ImagemPerfil;
                    empresa.Cnpj = usuarioViewModel.Cnpj;
                    empresa.Telefone = usuarioViewModel.Telefone;
                    empresa.Descricao = usuarioViewModel.Descricao;
                }
                else if (usuarioViewModel.Tipo == UsuarioTipo.Candidato && usuario is Candidato candidato)
                {
                    candidato.Nome = usuarioViewModel.Nome;
                    candidato.Email = usuarioViewModel.Email;
                    candidato.Senha = BCrypt.Net.BCrypt.HashPassword(usuarioViewModel.Senha);
                    candidato.ImagemPerfil = usuarioViewModel.ImagemPerfil;
                    candidato.Cpf = usuarioViewModel.Cpf;
                }
                else
                {
                    ModelState.AddModelError("", "Tipo de usuário inválido.");
                    await SignInUser(usuario);
                    return View(usuarioViewModel);
                }

                _context.Update(usuario);
                await SignInUser(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            await SignInUser(usuario);
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
                ImagemPerfil = usuario.ImagemPerfil,
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
