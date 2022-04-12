﻿#nullable disable
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
    public class GroupesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GroupesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Groupes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Groupes.Include(g => g.AnneeEtude).Include(g => g.AnneeScolaire);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Groupes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupe = await _context.Groupes
                .Include(g => g.AnneeEtude)
                .Include(g => g.AnneeScolaire)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupe == null)
            {
                return NotFound();
            }

            return View(groupe);
        }

        // GET: Groupes/Create
        public IActionResult Create()
        {
            ViewData["AnneeEtudeId"] = new SelectList(_context.AnneeEtudes, "Id", "Nom");
            ViewData["AnneeScolaireId"] = new SelectList(_context.AnneeScolaires, "Id", "Nom");
            return View();
        }

        // POST: Groupes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,AnneeEtudeId,AnneeScolaireId")] Groupe groupe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnneeEtudeId"] = new SelectList(_context.AnneeEtudes, "Id", "Nom", groupe.AnneeEtudeId);
            ViewData["AnneeScolaireId"] = new SelectList(_context.AnneeScolaires, "Id", "Nom", groupe.AnneeScolaireId);
            return View(groupe);
        }

        // GET: Groupes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupe = await _context.Groupes.FindAsync(id);
            if (groupe == null)
            {
                return NotFound();
            }
            ViewData["AnneeEtudeId"] = new SelectList(_context.AnneeEtudes, "Id", "Nom", groupe.AnneeEtudeId);
            ViewData["AnneeScolaireId"] = new SelectList(_context.AnneeScolaires, "Id", "Nom", groupe.AnneeScolaireId);
            return View(groupe);
        }

        // POST: Groupes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,AnneeEtudeId,AnneeScolaireId")] Groupe groupe)
        {
            if (id != groupe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupeExists(groupe.Id))
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
            ViewData["AnneeEtudeId"] = new SelectList(_context.AnneeEtudes, "Id", "Nom", groupe.AnneeEtudeId);
            ViewData["AnneeScolaireId"] = new SelectList(_context.AnneeScolaires, "Id", "Nom", groupe.AnneeScolaireId);
            return View(groupe);
        }

        // GET: Groupes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupe = await _context.Groupes
                .Include(g => g.AnneeEtude)
                .Include(g => g.AnneeScolaire)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupe == null)
            {
                return NotFound();
            }

            return View(groupe);
        }

        // POST: Groupes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupe = await _context.Groupes.FindAsync(id);
            _context.Groupes.Remove(groupe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupeExists(int id)
        {
            return _context.Groupes.Any(e => e.Id == id);
        }
    }
}
