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
    public class AnneeScolairesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnneeScolairesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AnneeScolaires
        public async Task<IActionResult> Index()
        {
            return View(await _context.AnneeScolaires.ToListAsync());
        }

        // GET: AnneeScolaires/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anneeScolaire = await _context.AnneeScolaires
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anneeScolaire == null)
            {
                return NotFound();
            }

            return View(anneeScolaire);
        }

        // GET: AnneeScolaires/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnneeScolaires/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom")] AnneeScolaire anneeScolaire)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anneeScolaire);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anneeScolaire);
        }

        // GET: AnneeScolaires/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anneeScolaire = await _context.AnneeScolaires.FindAsync(id);
            if (anneeScolaire == null)
            {
                return NotFound();
            }
            return View(anneeScolaire);
        }

        // POST: AnneeScolaires/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom")] AnneeScolaire anneeScolaire)
        {
            if (id != anneeScolaire.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anneeScolaire);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnneeScolaireExists(anneeScolaire.Id))
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
            return View(anneeScolaire);
        }

        // GET: AnneeScolaires/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anneeScolaire = await _context.AnneeScolaires
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anneeScolaire == null)
            {
                return NotFound();
            }

            return View(anneeScolaire);
        }

        // POST: AnneeScolaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anneeScolaire = await _context.AnneeScolaires.FindAsync(id);
            _context.AnneeScolaires.Remove(anneeScolaire);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnneeScolaireExists(int id)
        {
            return _context.AnneeScolaires.Any(e => e.Id == id);
        }
    }
}
