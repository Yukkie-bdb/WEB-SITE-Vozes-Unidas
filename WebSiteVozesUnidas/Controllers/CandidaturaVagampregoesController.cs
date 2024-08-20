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
    public class CandidaturaVagampregoesController : Controller
    {
        private readonly VozesDbContext _context;

        public CandidaturaVagampregoesController(VozesDbContext context)
        {
            _context = context;
        }

        // GET: CandidaturaVagampregoes
        public async Task<IActionResult> Index()
        {
            var vozesDbContext = _context.CandidaturaVagampregos.Include(c => c.Candidato).Include(c => c.Vaga);
            return View(await vozesDbContext.ToListAsync());
        }

        // GET: CandidaturaVagampregoes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidaturaVagamprego = await _context.CandidaturaVagampregos
                .Include(c => c.Candidato)
                .Include(c => c.Vaga)
                .FirstOrDefaultAsync(m => m.IdCandidaturaVagamprego == id);
            if (candidaturaVagamprego == null)
            {
                return NotFound();
            }

            return View(candidaturaVagamprego);
        }

        // GET: CandidaturaVagampregoes/Create
        public IActionResult Create()
        {
            ViewData["CandidatoId"] = new SelectList(_context.Candidato, "IdUsuario", "IdUsuario");
            ViewData["VagaId"] = new SelectList(_context.VagaEmprego, "IdVagaEmprego", "IdVagaEmprego");
            return View();
        }

        // POST: CandidaturaVagampregoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCandidaturaVagamprego,CandidatoId,VagaId")] CandidaturaVagamprego candidaturaVagamprego)
        {
            if (ModelState.IsValid)
            {
                candidaturaVagamprego.IdCandidaturaVagamprego = Guid.NewGuid();
                _context.Add(candidaturaVagamprego);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CandidatoId"] = new SelectList(_context.Candidato, "IdUsuario", "IdUsuario", candidaturaVagamprego.CandidatoId);
            ViewData["VagaId"] = new SelectList(_context.VagaEmprego, "IdVagaEmprego", "IdVagaEmprego", candidaturaVagamprego.VagaId);
            return View(candidaturaVagamprego);
        }

        // GET: CandidaturaVagampregoes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidaturaVagamprego = await _context.CandidaturaVagampregos.FindAsync(id);
            if (candidaturaVagamprego == null)
            {
                return NotFound();
            }
            ViewData["CandidatoId"] = new SelectList(_context.Candidato, "IdUsuario", "IdUsuario", candidaturaVagamprego.CandidatoId);
            ViewData["VagaId"] = new SelectList(_context.VagaEmprego, "IdVagaEmprego", "IdVagaEmprego", candidaturaVagamprego.VagaId);
            return View(candidaturaVagamprego);
        }

        // POST: CandidaturaVagampregoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdCandidaturaVagamprego,CandidatoId,VagaId")] CandidaturaVagamprego candidaturaVagamprego)
        {
            if (id != candidaturaVagamprego.IdCandidaturaVagamprego)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidaturaVagamprego);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidaturaVagampregoExists(candidaturaVagamprego.IdCandidaturaVagamprego))
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
            ViewData["CandidatoId"] = new SelectList(_context.Candidato, "IdUsuario", "IdUsuario", candidaturaVagamprego.CandidatoId);
            ViewData["VagaId"] = new SelectList(_context.VagaEmprego, "IdVagaEmprego", "IdVagaEmprego", candidaturaVagamprego.VagaId);
            return View(candidaturaVagamprego);
        }

        // GET: CandidaturaVagampregoes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidaturaVagamprego = await _context.CandidaturaVagampregos
                .Include(c => c.Candidato)
                .Include(c => c.Vaga)
                .FirstOrDefaultAsync(m => m.IdCandidaturaVagamprego == id);
            if (candidaturaVagamprego == null)
            {
                return NotFound();
            }

            return View(candidaturaVagamprego);
        }

        // POST: CandidaturaVagampregoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var candidaturaVagamprego = await _context.CandidaturaVagampregos.FindAsync(id);
            if (candidaturaVagamprego != null)
            {
                _context.CandidaturaVagampregos.Remove(candidaturaVagamprego);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidaturaVagampregoExists(Guid id)
        {
            return _context.CandidaturaVagampregos.Any(e => e.IdCandidaturaVagamprego == id);
        }
    }
}
