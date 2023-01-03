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
    public class PoradniaController : Controller
    {
        private readonly KlinikaContext _context;

        public PoradniaController(KlinikaContext context)
        {
            _context = context;
        }

        // GET: Poradnia
        public async Task<IActionResult> Index()
        {
            var klinikaContext = _context.Poradnia.Include(p => p.PoradniaTyp);
            return View(await klinikaContext.ToListAsync());
        }

        // GET: Poradnia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Poradnia == null)
            {
                return NotFound();
            }

            var poradnia = await _context.Poradnia
                .Include(p => p.PoradniaTyp)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (poradnia == null)
            {
                return NotFound();
            }

            return View(poradnia);
        }

        // GET: Poradnia/Create
        public IActionResult Create()
        {
            ViewData["PoradniaTypId"] = new SelectList(_context.PoradniaTyp, "Id", "Id");
            return View();
        }

        // POST: Poradnia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa,Opis,CzyAktywna,PoradniaTypId")] Poradnia poradnia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(poradnia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PoradniaTypId"] = new SelectList(_context.PoradniaTyp, "Id", "Id", poradnia.PoradniaTypId);
            return View(poradnia);
        }

        // GET: Poradnia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Poradnia == null)
            {
                return NotFound();
            }

            var poradnia = await _context.Poradnia.FindAsync(id);
            if (poradnia == null)
            {
                return NotFound();
            }
            ViewData["PoradniaTypId"] = new SelectList(_context.PoradniaTyp, "Id", "Id", poradnia.PoradniaTypId);
            return View(poradnia);
        }

        // POST: Poradnia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa,Opis,CzyAktywna,PoradniaTypId")] Poradnia poradnia)
        {
            if (id != poradnia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(poradnia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoradniaExists(poradnia.Id))
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
            ViewData["PoradniaTypId"] = new SelectList(_context.PoradniaTyp, "Id", "Id", poradnia.PoradniaTypId);
            return View(poradnia);
        }

        // GET: Poradnia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Poradnia == null)
            {
                return NotFound();
            }

            var poradnia = await _context.Poradnia
                .Include(p => p.PoradniaTyp)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (poradnia == null)
            {
                return NotFound();
            }

            return View(poradnia);
        }

        // POST: Poradnia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Poradnia == null)
            {
                return Problem("Entity set 'KlinikaContext.Poradnia'  is null.");
            }
            var poradnia = await _context.Poradnia.FindAsync(id);
            if (poradnia != null)
            {
                _context.Poradnia.Remove(poradnia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoradniaExists(int id)
        {
          return (_context.Poradnia?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
