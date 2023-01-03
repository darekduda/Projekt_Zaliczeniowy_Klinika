using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Klinika.Data.Data;
using Klinika.Data.Data.Entities;

namespace Klinika.Intranet.Controllers
{
    public class ZabiegController : Controller
    {
        private readonly KlinikaContext _context;

        public ZabiegController(KlinikaContext context)
        {
            _context = context;
        }

        // GET: Zabieg
        public async Task<IActionResult> Index()
        {
              return _context.Zabieg != null ? 
                          View(await _context.Zabieg.ToListAsync()) :
                          Problem("Entity set 'KlinikaContext.Zabieg'  is null.");
        }

        // GET: Zabieg/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Zabieg == null)
            {
                return NotFound();
            }

            var zabieg = await _context.Zabieg
                .FirstOrDefaultAsync(m => m.IdZabiegu == id);
            if (zabieg == null)
            {
                return NotFound();
            }

            return View(zabieg);
        }

        // GET: Zabieg/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zabieg/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdZabiegu,Nazwa,Opis,Cena,Przeciwwskazania,Przygotowania,CzasTrwania,CzyAktywny")] Zabieg zabieg)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zabieg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zabieg);
        }

        // GET: Zabieg/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Zabieg == null)
            {
                return NotFound();
            }

            var zabieg = await _context.Zabieg.FindAsync(id);
            if (zabieg == null)
            {
                return NotFound();
            }
            return View(zabieg);
        }

        // POST: Zabieg/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdZabiegu,Nazwa,Opis,Cena,Przeciwwskazania,Przygotowania,CzasTrwania,CzyAktywny")] Zabieg zabieg)
        {
            if (id != zabieg.IdZabiegu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zabieg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZabiegExists(zabieg.IdZabiegu))
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
            return View(zabieg);
        }

        // GET: Zabieg/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Zabieg == null)
            {
                return NotFound();
            }

            var zabieg = await _context.Zabieg
                .FirstOrDefaultAsync(m => m.IdZabiegu == id);
            if (zabieg == null)
            {
                return NotFound();
            }

            return View(zabieg);
        }

        // POST: Zabieg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Zabieg == null)
            {
                return Problem("Entity set 'KlinikaContext.Zabieg'  is null.");
            }
            var zabieg = await _context.Zabieg.FindAsync(id);
            if (zabieg != null)
            {
                _context.Zabieg.Remove(zabieg);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZabiegExists(int id)
        {
          return (_context.Zabieg?.Any(e => e.IdZabiegu == id)).GetValueOrDefault();
        }
    }
}
