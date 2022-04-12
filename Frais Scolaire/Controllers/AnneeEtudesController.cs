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
    public class AnneeEtudesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnneeEtudesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AnneeEtudes
        public async Task<IActionResult> Index()
        {
            return View(await _context.AnneeEtudes.ToListAsync());
        }

        // GET: AnneeEtudes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anneeEtude = await _context.AnneeEtudes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anneeEtude == null)
            {
                return NotFound();
            }

            return View(anneeEtude);
        }

        // GET: AnneeEtudes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnneeEtudes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom")] AnneeEtude anneeEtude)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anneeEtude);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anneeEtude);
        }

        // GET: AnneeEtudes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anneeEtude = await _context.AnneeEtudes.FindAsync(id);
            if (anneeEtude == null)
            {
                return NotFound();
            }
            return View(anneeEtude);
        }

        // POST: AnneeEtudes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom")] AnneeEtude anneeEtude)
        {
            if (id != anneeEtude.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anneeEtude);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnneeEtudeExists(anneeEtude.Id))
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
            return View(anneeEtude);
        }

        // GET: AnneeEtudes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anneeEtude = await _context.AnneeEtudes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anneeEtude == null)
            {
                return NotFound();
            }

            return View(anneeEtude);
        }

        // POST: AnneeEtudes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anneeEtude = await _context.AnneeEtudes.FindAsync(id);
            _context.AnneeEtudes.Remove(anneeEtude);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnneeEtudeExists(int id)
        {
            return _context.AnneeEtudes.Any(e => e.Id == id);
        }
    }
}
