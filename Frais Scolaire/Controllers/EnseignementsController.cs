#nullable disable
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
    public class EnseignementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnseignementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Enseignements
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Enseignements.Include(e => e.Groupe).Include(e => e.Matiere);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Enseignements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enseignement = await _context.Enseignements
                .Include(e => e.Groupe)
                .Include(e => e.Matiere)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enseignement == null)
            {
                return NotFound();
            }

            return View(enseignement);
        }

        // GET: Enseignements/Create
        public IActionResult Create()
        {
            ViewData["GroupeId"] = new SelectList(_context.Groupes, "Id", "Nom");
            ViewData["MatiereId"] = new SelectList(_context.Matieres, "Id", "Nom");
            return View();
        }

        // POST: Enseignements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GroupeId,MatiereId")] Enseignement enseignement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enseignement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupeId"] = new SelectList(_context.Groupes, "Id", "Nom", enseignement.GroupeId);
            ViewData["MatiereId"] = new SelectList(_context.Matieres, "Id", "Nom", enseignement.MatiereId);
            return View(enseignement);
        }

        // GET: Enseignements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enseignement = await _context.Enseignements.FindAsync(id);
            if (enseignement == null)
            {
                return NotFound();
            }
            ViewData["GroupeId"] = new SelectList(_context.Groupes, "Id", "Nom", enseignement.GroupeId);
            ViewData["MatiereId"] = new SelectList(_context.Matieres, "Id", "Nom", enseignement.MatiereId);
            return View(enseignement);
        }

        // POST: Enseignements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GroupeId,MatiereId")] Enseignement enseignement)
        {
            if (id != enseignement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enseignement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnseignementExists(enseignement.Id))
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
            ViewData["GroupeId"] = new SelectList(_context.Groupes, "Id", "Nom", enseignement.GroupeId);
            ViewData["MatiereId"] = new SelectList(_context.Matieres, "Id", "Nom", enseignement.MatiereId);
            return View(enseignement);
        }

        // GET: Enseignements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enseignement = await _context.Enseignements
                .Include(e => e.Groupe)
                .Include(e => e.Matiere)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enseignement == null)
            {
                return NotFound();
            }

            return View(enseignement);
        }

        // POST: Enseignements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enseignement = await _context.Enseignements.FindAsync(id);
            _context.Enseignements.Remove(enseignement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnseignementExists(int id)
        {
            return _context.Enseignements.Any(e => e.Id == id);
        }
    }
}
