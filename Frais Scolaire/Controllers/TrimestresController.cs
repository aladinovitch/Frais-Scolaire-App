using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Frais_Scolaire.Data;
using Frais_Scolaire.Models;

namespace Frais_Scolaire.Controllers
{
    public class TrimestresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrimestresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Trimestres
        public async Task<IActionResult> Index()
        {
              return _context.Trimestres != null ? 
                          View(await _context.Trimestres.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Trimestres'  is null.");
        }

        // GET: Trimestres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Trimestres == null)
            {
                return NotFound();
            }

            var trimestre = await _context.Trimestres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trimestre == null)
            {
                return NotFound();
            }

            return View(trimestre);
        }

        // GET: Trimestres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trimestres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,DateDebut,DateFin")] Trimestre trimestre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trimestre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trimestre);
        }

        // GET: Trimestres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Trimestres == null)
            {
                return NotFound();
            }

            var trimestre = await _context.Trimestres.FindAsync(id);
            if (trimestre == null)
            {
                return NotFound();
            }
            return View(trimestre);
        }

        // POST: Trimestres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,DateDebut,DateFin")] Trimestre trimestre)
        {
            if (id != trimestre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trimestre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrimestreExists(trimestre.Id))
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
            return View(trimestre);
        }

        // GET: Trimestres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Trimestres == null)
            {
                return NotFound();
            }

            var trimestre = await _context.Trimestres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trimestre == null)
            {
                return NotFound();
            }

            return View(trimestre);
        }

        // POST: Trimestres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Trimestres == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Trimestres'  is null.");
            }
            var trimestre = await _context.Trimestres.FindAsync(id);
            if (trimestre != null)
            {
                _context.Trimestres.Remove(trimestre);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrimestreExists(int id)
        {
          return (_context.Trimestres?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
