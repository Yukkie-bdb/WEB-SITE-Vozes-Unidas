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
    public class VagaEmpregoesController : Controller
    {
        private readonly VozesDbContext _context;

        public VagaEmpregoesController(VozesDbContext context)
        {
            _context = context;
        }

        // GET: VagaEmpregoes
        public async Task<IActionResult> Index()
        {
            var vozesDbContext = _context.VagaEmprego.Include(v => v.Empresa);
            return View(await vozesDbContext.ToListAsync());
        }

        // GET: VagaEmpregoes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vagaEmprego = await _context.VagaEmprego
                .Include(v => v.Empresa)
                .FirstOrDefaultAsync(m => m.IdVagaEmprego == id);
            if (vagaEmprego == null)
            {
                return NotFound();
            }

            return View(vagaEmprego);
        }

        // GET: VagaEmpregoes/Create
        public IActionResult Create()
        {
            ViewData["EmpresaId"] = new SelectList(_context.Empresa, "IdUsuario", "IdUsuario");
            return View();
        }

        // POST: VagaEmpregoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVagaEmprego,Titulo,Descricao,Requisitos,DataPublicacao,EmpresaId")] VagaEmprego vagaEmprego)
        {
            if (ModelState.IsValid)
            {
                vagaEmprego.IdVagaEmprego = Guid.NewGuid();
                _context.Add(vagaEmprego);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresa, "IdUsuario", "IdUsuario", vagaEmprego.EmpresaId);
            return View(vagaEmprego);
        }

        // GET: VagaEmpregoes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vagaEmprego = await _context.VagaEmprego.FindAsync(id);
            if (vagaEmprego == null)
            {
                return NotFound();
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresa, "IdUsuario", "IdUsuario", vagaEmprego.EmpresaId);
            return View(vagaEmprego);
        }

        // POST: VagaEmpregoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdVagaEmprego,Titulo,Descricao,Requisitos,DataPublicacao,EmpresaId")] VagaEmprego vagaEmprego)
        {
            if (id != vagaEmprego.IdVagaEmprego)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vagaEmprego);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VagaEmpregoExists(vagaEmprego.IdVagaEmprego))
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
            ViewData["EmpresaId"] = new SelectList(_context.Empresa, "IdUsuario", "IdUsuario", vagaEmprego.EmpresaId);
            return View(vagaEmprego);
        }

        // GET: VagaEmpregoes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vagaEmprego = await _context.VagaEmprego
                .Include(v => v.Empresa)
                .FirstOrDefaultAsync(m => m.IdVagaEmprego == id);
            if (vagaEmprego == null)
            {
                return NotFound();
            }

            return View(vagaEmprego);
        }

        // POST: VagaEmpregoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var vagaEmprego = await _context.VagaEmprego.FindAsync(id);
            if (vagaEmprego != null)
            {
                _context.VagaEmprego.Remove(vagaEmprego);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VagaEmpregoExists(Guid id)
        {
            return _context.VagaEmprego.Any(e => e.IdVagaEmprego == id);
        }
    }
}
