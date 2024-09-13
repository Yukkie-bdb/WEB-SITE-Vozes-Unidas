using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebSiteVozesUnidas.Data;
using WebSiteVozesUnidas.Models;

namespace WebSiteVozesUnidas.Controllers
{
    public class NoticiasController : Controller
    {
        private readonly VozesDbContext _context;
        private string _caminho;

        public NoticiasController(VozesDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _caminho = hostEnvironment.WebRootPath;

        }

        // GET: Noticias
        public async Task<IActionResult> Index()
        {
            var vozesDbContext = _context.Noticia.Include(n => n.Usuario);
            return View(await vozesDbContext.ToListAsync());
        }

        // GET: Noticias/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticia = await _context.Noticia
                .Include(n => n.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (noticia == null)
            {
                return NotFound();
            }

            return View(noticia);
        }

        // GET: Noticias/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "IdUsuario", "Nome");
            return View();
        }

        // POST: Noticias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Resumo,Descricao,ImgCapa,Publicacao,UsuarioId")] Noticia noticia, IFormFile imgUp)
        {
            if (ModelState.IsValid)
            {
                noticia.Id = Guid.NewGuid();

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
                    noticia.ImgCapa = uniqueFileName;
                }


                    //var userName = User.Identity.Name;

                    var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "UsuarioId");
                    var userId = userIdClaim?.Value;

                    //var userTypeClaim = User.Claims.FirstOrDefault(c => c.Type == "UsuarioTipo");
                    //var userType = userTypeClaim?.Value;
    

                noticia.UsuarioId = Guid.Parse(userId);
                _context.Add(noticia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "IdUsuario", "Nome", noticia.UsuarioId);
            return View(noticia);
        }

        // GET: Noticias/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticia = await _context.Noticia.FindAsync(id);
            if (noticia == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "IdUsuario", "IdUsuario", noticia.UsuarioId);
            return View(noticia);
        }

        // POST: Noticias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Titulo,Resumo,Descricao,ImgCapa,Publicacao,UsuarioId")] Noticia noticia)
        {
            if (id != noticia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(noticia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoticiaExists(noticia.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "IdUsuario", "IdUsuario", noticia.UsuarioId);
            return View(noticia);
        }

        // GET: Noticias/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticia = await _context.Noticia
                .Include(n => n.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (noticia == null)
            {
                return NotFound();
            }

            return View(noticia);
        }

        // POST: Noticias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var noticia = await _context.Noticia.FindAsync(id);

            if (noticia.ImgCapa != null && noticia.ImgCapa.Length > 0)
            {
                string uploadsFolder = Path.Combine(_caminho, "img");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string filePath = Path.Combine(uploadsFolder, noticia.ImgCapa);

                noticia.ImgCapa = filePath;

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }

            if (noticia != null)
            {
                _context.Noticia.Remove(noticia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoticiaExists(Guid id)
        {
            return _context.Noticia.Any(e => e.Id == id);
        }
    }
}
