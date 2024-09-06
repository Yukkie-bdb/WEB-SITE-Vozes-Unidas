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
    public class CandidatoJornalistasController : Controller
    {
        private readonly VozesDbContext _context;

        public CandidatoJornalistasController(VozesDbContext context)
        {
            _context = context;
        }

        // GET: CandidatoJornalistas
        public async Task<IActionResult> Index()
        {
            var vozesDbContext = _context.CandidatoJornalistas.Include(c => c.Candidato);
            return View(await vozesDbContext.ToListAsync());
        }

        // GET: CandidatoJornalistas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatoJornalista = await _context.CandidatoJornalistas
                .Include(c => c.Candidato)
                .FirstOrDefaultAsync(m => m.IdCandidatoJornalista == id);
            if (candidatoJornalista == null)
            {
                return NotFound();
            }

            return View(candidatoJornalista);
        }

        // GET: CandidatoJornalistas/Create
        public IActionResult Create()
        {
            ViewData["CandidatoId"] = new SelectList(_context.Candidato, "IdUsuario", "IdUsuario");
            return View();
        }

        // POST: CandidatoJornalistas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCandidatoJornalista,CandidatoId")] CandidatoJornalista candidatoJornalista)
        {
            if (ModelState.IsValid)
            {
                candidatoJornalista.IdCandidatoJornalista = Guid.NewGuid();
                _context.Add(candidatoJornalista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CandidatoId"] = new SelectList(_context.Candidato, "IdUsuario", "IdUsuario", candidatoJornalista.CandidatoId);
            return View(candidatoJornalista);
        }

        // GET: CandidatoJornalistas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatoJornalista = await _context.CandidatoJornalistas.FindAsync(id);
            if (candidatoJornalista == null)
            {
                return NotFound();
            }
            ViewData["CandidatoId"] = new SelectList(_context.Candidato, "IdUsuario", "IdUsuario", candidatoJornalista.CandidatoId);
            return View(candidatoJornalista);
        }

        // POST: CandidatoJornalistas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdCandidatoJornalista,CandidatoId")] CandidatoJornalista candidatoJornalista)
        {
            if (id != candidatoJornalista.IdCandidatoJornalista)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidatoJornalista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidatoJornalistaExists(candidatoJornalista.IdCandidatoJornalista))
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
            ViewData["CandidatoId"] = new SelectList(_context.Candidato, "IdUsuario", "IdUsuario", candidatoJornalista.CandidatoId);
            return View(candidatoJornalista);
        }

        // GET: CandidatoJornalistas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatoJornalista = await _context.CandidatoJornalistas
                .Include(c => c.Candidato)
                .FirstOrDefaultAsync(m => m.IdCandidatoJornalista == id);
            if (candidatoJornalista == null)
            {
                return NotFound();
            }

            return View(candidatoJornalista);
        }

        // POST: CandidatoJornalistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var candidatoJornalista = await _context.CandidatoJornalistas.FindAsync(id);
            if (candidatoJornalista != null)
            {
                _context.CandidatoJornalistas.Remove(candidatoJornalista);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidatoJornalistaExists(Guid id)
        {
            return _context.CandidatoJornalistas.Any(e => e.IdCandidatoJornalista == id);
        }
    }
}
