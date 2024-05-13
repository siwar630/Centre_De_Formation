using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Centre_de_formation.Models;

namespace Centre_de_formation.Controllers
{
    public class FormateursController : Controller
    {
        private readonly CentreFormationContext _context;

        public FormateursController(CentreFormationContext context)
        {
            _context = context;
        }

        // GET: Formateurs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Formateurs.ToListAsync());
        }

        // GET: Formateurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formateur = await _context.Formateurs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formateur == null)
            {
                return NotFound();
            }

            return View(formateur);
        }

        // GET: Formateurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Formateurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Prenom,Tel,Salaire")] Formateur formateur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formateur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formateur);
        }

        // GET: Formateurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formateur = await _context.Formateurs.FindAsync(id);
            if (formateur == null)
            {
                return NotFound();
            }
            return View(formateur);
        }

        // POST: Formateurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Salaire,Nom,Prenom,Tel")] Formateur formateur)
        {
            if (id != formateur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formateur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormateurExists(formateur.Id))
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
            return View(formateur);
        }

        // GET: Formateurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formateur = await _context.Formateurs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formateur == null)
            {
                return NotFound();
            }

            return View(formateur);
        }

        // POST: Formateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formateur = await _context.Formateurs.FindAsync(id);
            if (formateur != null)
            {
                _context.Formateurs.Remove(formateur);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormateurExists(int id)
        {
            return _context.Formateurs.Any(e => e.Id == id);
        }
    }
}
