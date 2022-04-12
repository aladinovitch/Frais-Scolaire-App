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
    public class ElevesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ElevesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Eleves
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Eleves.Include(e => e.Groupe);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Eleves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eleve = await _context.Eleves
                .Include(e => e.Groupe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eleve == null)
            {
                return NotFound();
            }

            return View(eleve);
        }

        // GET: Eleves/Create
        public IActionResult Create()
        {
            ViewData["GroupeId"] = new SelectList(_context.Groupes, "Id", "Nom");
            return View();
        }

        // POST: Eleves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Matricule,Prenom,Nom,Naissance,Sexe,Phone,Email,Adresse,GroupeId")] Eleve eleve)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eleve);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupeId"] = new SelectList(_context.Groupes, "Id", "Nom", eleve.GroupeId);
            return View(eleve);
        }

        // GET: Eleves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eleve = await _context.Eleves.FindAsync(id);
            if (eleve == null)
            {
                return NotFound();
            }
            ViewData["GroupeId"] = new SelectList(_context.Groupes, "Id", "Nom", eleve.GroupeId);
            return View(eleve);
        }

        // POST: Eleves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Matricule,Prenom,Nom,Naissance,Sexe,Phone,Email,Adresse,GroupeId")] Eleve eleve)
        {
            if (id != eleve.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eleve);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EleveExists(eleve.Id))
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
            ViewData["GroupeId"] = new SelectList(_context.Groupes, "Id", "Nom", eleve.GroupeId);
            return View(eleve);
        }

        // GET: Eleves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eleve = await _context.Eleves
                .Include(e => e.Groupe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eleve == null)
            {
                return NotFound();
            }

            return View(eleve);
        }

        // POST: Eleves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eleve = await _context.Eleves.FindAsync(id);
            _context.Eleves.Remove(eleve);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EleveExists(int id)
        {
            return _context.Eleves.Any(e => e.Id == id);
        }
    }
}
