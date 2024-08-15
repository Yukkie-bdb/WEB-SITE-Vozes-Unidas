using Microsoft.AspNetCore.Mvc;
using WebSiteVozesUnidas.Models;
using WebSiteVozesUnidas.Data;
using WebSiteVozesUnidas.ViewModels;

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
            return View();
        }
        // GET: Usuario/Create
        public IActionResult Create()
        {
            return View(new UsuarioViewModel());
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UsuarioViewModel usuarioViewModel)
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
                        Senha = usuarioViewModel.Senha,
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
                        Senha = usuarioViewModel.Senha,
                        Tipo = usuarioViewModel.Tipo,
                        Cpf = usuarioViewModel.Cpf
                    };
                }

                _context.Usuario.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(usuarioViewModel);
        }
    

    }
}
