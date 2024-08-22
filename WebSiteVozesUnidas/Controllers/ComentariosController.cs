using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSiteVozesUnidas.Data;
using WebSiteVozesUnidas.Models;

namespace WebSiteVozesUnidas.Controllers
{
    public class ComentariosController : Controller
    {
        private readonly VozesDbContext _context;

        public ComentariosController(VozesDbContext context)
        {
            _context = context;
        }

        // GET: Comentarios
        public async Task<IActionResult> Index()
        {
            var vozesDbContext = _context.Comentario.Include(c => c.Post).Include(c => c.Usuario);
            return View(await vozesDbContext.ToListAsync());
        }

        // GET: Comentarios/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentario = await _context.Comentario
                .Include(c => c.Post)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.IdComentario == id);
            if (comentario == null)
            {
                return NotFound();
            }

            return View(comentario);
        }

        // GET: Comentarios/Create
        public IActionResult Create()
        {
            ViewData["PostId"] = new SelectList(_context.Post, "IdPost", "IdPost");
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "IdUsuario", "IdUsuario");
            return View();
        }

        // POST: Comentarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdComentario,Conteudo,PostId")] Comentario comentario)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "UsuarioId");
            var userId = userIdClaim.Value;

            comentario.UsuarioId = Guid.Parse(userId);

            if (ModelState.IsValid)
            {
                comentario.IdComentario = Guid.NewGuid();
                _context.Add(comentario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["PostId"] = new SelectList(_context.Post, "IdPost", "IdPost", comentario.PostId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "IdUsuario", "IdUsuario", comentario.UsuarioId);
            return View(comentario);
        }

        // GET: Comentarios/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentario = await _context.Comentario.FindAsync(id);
            if (comentario == null)
            {
                return NotFound();
            }
            ViewData["PostId"] = new SelectList(_context.Post, "IdPost", "IdPost", comentario.PostId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "IdUsuario", "IdUsuario", comentario.UsuarioId);
            return View(comentario);
        }

        // POST: Comentarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdComentario,Conteudo,PostId,UsuarioId")] Comentario comentario)
        {
            if (id != comentario.IdComentario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comentario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComentarioExists(comentario.IdComentario))
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
            ViewData["PostId"] = new SelectList(_context.Post, "IdPost", "IdPost", comentario.PostId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "IdUsuario", "IdUsuario", comentario.UsuarioId);
            return View(comentario);
        }

        // GET: Comentarios/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentario = await _context.Comentario
                .Include(c => c.Post)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.IdComentario == id);
            if (comentario == null)
            {
                return NotFound();
            }

            return View(comentario);
        }

        // POST: Comentarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var comentario = await _context.Comentario.FindAsync(id);
            if (comentario != null)
            {
                _context.Comentario.Remove(comentario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComentarioExists(Guid id)
        {
            return _context.Comentario.Any(e => e.IdComentario == id);
        }
    }
}
