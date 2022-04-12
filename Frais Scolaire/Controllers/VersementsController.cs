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
    public class VersementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VersementsController(ApplicationDbContext context) {
            _context = context;
        }

        // GET: Versements
        public async Task<IActionResult> Index() {
            var applicationDbContext = _context.Versements.Include(v => v.Etudiant).Include(v => v.Paiement);
            if (User.HasClaim(AppClaimType.Manager, "true"))
                return View(await applicationDbContext.ToListAsync());
            return View("IndexReadonly", await applicationDbContext.ToListAsync());
        }

        [Authorize(Policy = AppPolicyName.Management)]
        // GET: Versements/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var versement = await _context.Versements
                .Include(v => v.Etudiant)
                .Include(v => v.Paiement)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (versement == null) {
                return NotFound();
            }

            return View(versement);
        }

        [Authorize(Policy = AppPolicyName.Management)]
        // GET: Versements/Create
        public IActionResult Create() {
            ViewData["EtudiantId"] = new SelectList(_context.Eleves, "Id", "Fullname");
            ViewData["PaiementId"] = new SelectList(_context.Paiements, "Id", "Nom");
            return View();
        }

        // POST: Versements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EtudiantId,PaiementId")] Versement versement) {
            if (ModelState.IsValid) {
                _context.Add(versement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EtudiantId"] = new SelectList(_context.Eleves, "Id", "Fullname", versement.EtudiantId);
            ViewData["PaiementId"] = new SelectList(_context.Paiements, "Id", "Nom", versement.PaiementId);
            return View(versement);
        }

        [Authorize(Policy = AppPolicyName.Management)]
        // GET: Versements/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var versement = await _context.Versements.FindAsync(id);
            if (versement == null) {
                return NotFound();
            }
            ViewData["EtudiantId"] = new SelectList(_context.Eleves, "Id", "Fullname", versement.EtudiantId);
            ViewData["PaiementId"] = new SelectList(_context.Paiements, "Id", "Nom", versement.PaiementId);
            return View(versement);
        }

        // POST: Versements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EtudiantId,PaiementId")] Versement versement) {
            if (id != versement.Id) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(versement);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!VersementExists(versement.Id)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EtudiantId"] = new SelectList(_context.Eleves, "Id", "Fullname", versement.EtudiantId);
            ViewData["PaiementId"] = new SelectList(_context.Paiements, "Id", "Nom", versement.PaiementId);
            return View(versement);
        }

        [Authorize(Policy = AppPolicyName.Management)]
        // GET: Versements/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var versement = await _context.Versements
                .Include(v => v.Etudiant)
                .Include(v => v.Paiement)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (versement == null) {
                return NotFound();
            }

            return View(versement);
        }

        // POST: Versements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var versement = await _context.Versements.FindAsync(id);
            _context.Versements.Remove(versement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VersementExists(int id) {
            return _context.Versements.Any(e => e.Id == id);
        }
    }
}
