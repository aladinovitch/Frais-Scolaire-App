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
    public class MatieresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MatieresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Matieres
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Matieres.Include(m => m.Enseignant);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Matieres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matiere = await _context.Matieres
                .Include(m => m.Enseignant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matiere == null)
            {
                return NotFound();
            }

            return View(matiere);
        }

        // GET: Matieres/Create
        public IActionResult Create()
        {
            ViewData["EnseignantId"] = new SelectList(_context.Enseignants, "Id", "Fullname");
            return View();
        }

        // POST: Matieres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,EnseignantId")] Matiere matiere)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matiere);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnseignantId"] = new SelectList(_context.Enseignants, "Id", "Fullname", matiere.EnseignantId);
            return View(matiere);
        }

        // GET: Matieres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matiere = await _context.Matieres.FindAsync(id);
            if (matiere == null)
            {
                return NotFound();
            }
            ViewData["EnseignantId"] = new SelectList(_context.Enseignants, "Id", "Fullname", matiere.EnseignantId);
            return View(matiere);
        }

        // POST: Matieres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,EnseignantId")] Matiere matiere)
        {
            if (id != matiere.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matiere);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatiereExists(matiere.Id))
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
            ViewData["EnseignantId"] = new SelectList(_context.Enseignants, "Id", "Fullname", matiere.EnseignantId);
            return View(matiere);
        }

        // GET: Matieres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matiere = await _context.Matieres
                .Include(m => m.Enseignant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matiere == null)
            {
                return NotFound();
            }

            return View(matiere);
        }

        // POST: Matieres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matiere = await _context.Matieres.FindAsync(id);
            _context.Matieres.Remove(matiere);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatiereExists(int id)
        {
            return _context.Matieres.Any(e => e.Id == id);
        }
    }
}
