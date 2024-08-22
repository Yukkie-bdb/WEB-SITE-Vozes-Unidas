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
    public class PostsController : Controller
    {
        private readonly VozesDbContext _context;

        public PostsController(VozesDbContext context)
        {
            _context = context;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            var vozesDbContext = _context.Post.Include(p => p.CategoriaPost).Include(p => p.Usuario);
            return View(await vozesDbContext.ToListAsync());
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .Include(p => p.CategoriaPost)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.IdPost == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            ViewData["CategoriaPostId"] = new SelectList(_context.CategoriaPost, "IdCategoriaPost", "IdCategoriaPost");
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "IdUsuario", "IdUsuario");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPost,Titulo,Conteudo,ImgPost,Horario,CategoriaPostId")] Post post)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "UsuarioId");
            var userId = userIdClaim.Value;

            post.UsuarioId = Guid.Parse(userId);
            if (ModelState.IsValid)
            {
                post.IdPost = Guid.NewGuid();
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaPostId"] = new SelectList(_context.CategoriaPost, "IdCategoriaPost", "IdCategoriaPost", post.CategoriaPostId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "IdUsuario", "IdUsuario", post.UsuarioId);
            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["CategoriaPostId"] = new SelectList(_context.CategoriaPost, "IdCategoriaPost", "IdCategoriaPost", post.CategoriaPostId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "IdUsuario", "IdUsuario", post.UsuarioId);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdPost,Titulo,Conteudo,ImgPost,Horario,UsuarioId,CategoriaPostId")] Post post)
        {
            if (id != post.IdPost)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.IdPost))
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
            ViewData["CategoriaPostId"] = new SelectList(_context.CategoriaPost, "IdCategoriaPost", "IdCategoriaPost", post.CategoriaPostId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "IdUsuario", "IdUsuario", post.UsuarioId);
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .Include(p => p.CategoriaPost)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.IdPost == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var post = await _context.Post.FindAsync(id);
            if (post != null)
            {
                _context.Post.Remove(post);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(Guid id)
        {
            return _context.Post.Any(e => e.IdPost == id);
        }
    }
}
