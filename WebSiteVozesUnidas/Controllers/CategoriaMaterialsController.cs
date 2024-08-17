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
    public class CategoriaMaterialsController : Controller
    {
        private readonly VozesDbContext _context;

        public CategoriaMaterialsController(VozesDbContext context)
        {
            _context = context;
        }

        // GET: CategoriaMaterials
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoriaMaterial.ToListAsync());
        }

        // GET: CategoriaMaterials/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaMaterial = await _context.CategoriaMaterial
                .FirstOrDefaultAsync(m => m.IdCategoriaMaterial == id);
            if (categoriaMaterial == null)
            {
                return NotFound();
            }

            return View(categoriaMaterial);
        }

        // GET: CategoriaMaterials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaMaterials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCategoriaMaterial,Categoria")] CategoriaMaterial categoriaMaterial)
        {
            if (ModelState.IsValid)
            {
                categoriaMaterial.IdCategoriaMaterial = Guid.NewGuid();
                _context.Add(categoriaMaterial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaMaterial);
        }

        // GET: CategoriaMaterials/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaMaterial = await _context.CategoriaMaterial.FindAsync(id);
            if (categoriaMaterial == null)
            {
                return NotFound();
            }
            return View(categoriaMaterial);
        }

        // POST: CategoriaMaterials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdCategoriaMaterial,Categoria")] CategoriaMaterial categoriaMaterial)
        {
            if (id != categoriaMaterial.IdCategoriaMaterial)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaMaterial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaMaterialExists(categoriaMaterial.IdCategoriaMaterial))
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
            return View(categoriaMaterial);
        }

        // GET: CategoriaMaterials/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaMaterial = await _context.CategoriaMaterial
                .FirstOrDefaultAsync(m => m.IdCategoriaMaterial == id);
            if (categoriaMaterial == null)
            {
                return NotFound();
            }

            return View(categoriaMaterial);
        }

        // POST: CategoriaMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var categoriaMaterial = await _context.CategoriaMaterial.FindAsync(id);
            if (categoriaMaterial != null)
            {
                _context.CategoriaMaterial.Remove(categoriaMaterial);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaMaterialExists(Guid id)
        {
            return _context.CategoriaMaterial.Any(e => e.IdCategoriaMaterial == id);
        }
    }
}
