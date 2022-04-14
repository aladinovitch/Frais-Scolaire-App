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
using Microsoft.AspNetCore.Authorization;

namespace Frais_Scolaire.Controllers
{
    [Authorize(Policy = AppPolicyName.Accessing)]
    public class AbsencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AbsencesController(ApplicationDbContext context) {
            _context = context;
        }

        // GET: Absences
        public async Task<IActionResult> Index() {
            var applicationDbContext = _context.Absences.Include(a => a.Eleve).Include(a => a.Seance);
            if (User.HasClaim(AppClaimType.Manager, "true"))
                return View(await applicationDbContext.ToListAsync());
            return View("IndexReadonly", await applicationDbContext.ToListAsync());
        }

        [Authorize(Policy = AppPolicyName.Management)]
        // GET: Absences/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var absence = await _context.Absences
                .Include(a => a.Eleve)
                .Include(a => a.Seance)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (absence == null) {
                return NotFound();
            }

            return View(absence);
        }

        [Authorize(Policy = AppPolicyName.Management)]
        // GET: Absences/Create
        public IActionResult Create() {
            ViewData["EleveId"] = new SelectList(_context.Eleves, "Id", "Fullname");
            ViewData["SeanceId"] = new SelectList(_context.Seances, "Id", "Id");
            return View();
        }

        // POST: Absences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Justification,EleveId,SeanceId")] Absence absence) {
            if (ModelState.IsValid) {
                _context.Add(absence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EleveId"] = new SelectList(_context.Eleves, "Id", "Fullname", absence.EleveId);
            ViewData["SeanceId"] = new SelectList(_context.Seances, "Id", "Id", absence.SeanceId);
            return View(absence);
        }

        [Authorize(Policy = AppPolicyName.Management)]
        // GET: Absences/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var absence = await _context.Absences.FindAsync(id);
            if (absence == null) {
                return NotFound();
            }
            ViewData["EleveId"] = new SelectList(_context.Eleves, "Id", "Fullname", absence.EleveId);
            ViewData["SeanceId"] = new SelectList(_context.Seances, "Id", "Id", absence.SeanceId);
            return View(absence);
        }

        // POST: Absences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Justification,EleveId,SeanceId")] Absence absence) {
            if (id != absence.Id) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(absence);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!AbsenceExists(absence.Id)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EleveId"] = new SelectList(_context.Eleves, "Id", "Fullname", absence.EleveId);
            ViewData["SeanceId"] = new SelectList(_context.Seances, "Id", "Id", absence.SeanceId);
            return View(absence);
        }

        [Authorize(Policy = AppPolicyName.Management)]
        // GET: Absences/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var absence = await _context.Absences
                .Include(a => a.Eleve)
                .Include(a => a.Seance)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (absence == null) {
                return NotFound();
            }

            return View(absence);
        }

        // POST: Absences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var absence = await _context.Absences.FindAsync(id);
            _context.Absences.Remove(absence);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AbsenceExists(int id) {
            return _context.Absences.Any(e => e.Id == id);
        }
    }
}
