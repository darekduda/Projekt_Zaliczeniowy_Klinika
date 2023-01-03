using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Klinika.Data.Data;
using Klinika.Data.Data.CMS;

namespace Klinika.Intranet.Controllers
{
    public class OpeningHoursController : Controller
    {
        private readonly KlinikaContext _context;

        public OpeningHoursController(KlinikaContext context)
        {
            _context = context;
        }

        // GET: OpeningHours
        public async Task<IActionResult> Index()
        {
              return _context.OpeningHours != null ? 
                          View(await _context.OpeningHours.ToListAsync()) :
                          Problem("Entity set 'KlinikaContext.OpeningHours'  is null.");
        }

        // GET: OpeningHours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OpeningHours == null)
            {
                return NotFound();
            }

            var openingHours = await _context.OpeningHours
                .FirstOrDefaultAsync(m => m.IdGodzinyOtwarcia == id);
            if (openingHours == null)
            {
                return NotFound();
            }

            return View(openingHours);
        }

        // GET: OpeningHours/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OpeningHours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGodzinyOtwarcia,Dzien,GodzinaOtwarciaOd,GodzinaOtwarciaDo,PozycjaWyswietlania,CzyAktywny")] OpeningHours openingHours)
        {
            if (ModelState.IsValid)
            {
                _context.Add(openingHours);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(openingHours);
        }

        // GET: OpeningHours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OpeningHours == null)
            {
                return NotFound();
            }

            var openingHours = await _context.OpeningHours.FindAsync(id);
            if (openingHours == null)
            {
                return NotFound();
            }
            return View(openingHours);
        }

        // POST: OpeningHours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGodzinyOtwarcia,Dzien,GodzinaOtwarciaOd,GodzinaOtwarciaDo,PozycjaWyswietlania,CzyAktywny")] OpeningHours openingHours)
        {
            if (id != openingHours.IdGodzinyOtwarcia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(openingHours);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpeningHoursExists(openingHours.IdGodzinyOtwarcia))
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
            return View(openingHours);
        }

        // GET: OpeningHours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OpeningHours == null)
            {
                return NotFound();
            }

            var openingHours = await _context.OpeningHours
                .FirstOrDefaultAsync(m => m.IdGodzinyOtwarcia == id);
            if (openingHours == null)
            {
                return NotFound();
            }

            return View(openingHours);
        }

        // POST: OpeningHours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OpeningHours == null)
            {
                return Problem("Entity set 'KlinikaContext.OpeningHours'  is null.");
            }
            var openingHours = await _context.OpeningHours.FindAsync(id);
            if (openingHours != null)
            {
                _context.OpeningHours.Remove(openingHours);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OpeningHoursExists(int id)
        {
          return (_context.OpeningHours?.Any(e => e.IdGodzinyOtwarcia == id)).GetValueOrDefault();
        }
    }
}
