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
    public class PoradniaTypController : Controller
    {
        private readonly KlinikaContext _context;

        public PoradniaTypController(KlinikaContext context)
        {
            _context = context;
        }

        // GET: PoradniaTyp
        public async Task<IActionResult> Index()
        {
              return _context.PoradniaTyp != null ? 
                          View(await _context.PoradniaTyp.ToListAsync()) :
                          Problem("Entity set 'KlinikaContext.PoradniaTyp'  is null.");
        }

        // GET: PoradniaTyp/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PoradniaTyp == null)
            {
                return NotFound();
            }

            var poradniaTyp = await _context.PoradniaTyp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (poradniaTyp == null)
            {
                return NotFound();
            }

            return View(poradniaTyp);
        }

        // GET: PoradniaTyp/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PoradniaTyp/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa")] PoradniaTyp poradniaTyp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(poradniaTyp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(poradniaTyp);
        }

        // GET: PoradniaTyp/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PoradniaTyp == null)
            {
                return NotFound();
            }

            var poradniaTyp = await _context.PoradniaTyp.FindAsync(id);
            if (poradniaTyp == null)
            {
                return NotFound();
            }
            return View(poradniaTyp);
        }

        // POST: PoradniaTyp/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa")] PoradniaTyp poradniaTyp)
        {
            if (id != poradniaTyp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(poradniaTyp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoradniaTypExists(poradniaTyp.Id))
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
            return View(poradniaTyp);
        }

        // GET: PoradniaTyp/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PoradniaTyp == null)
            {
                return NotFound();
            }

            var poradniaTyp = await _context.PoradniaTyp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (poradniaTyp == null)
            {
                return NotFound();
            }

            return View(poradniaTyp);
        }

        // POST: PoradniaTyp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PoradniaTyp == null)
            {
                return Problem("Entity set 'KlinikaContext.PoradniaTyp'  is null.");
            }
            var poradniaTyp = await _context.PoradniaTyp.FindAsync(id);
            if (poradniaTyp != null)
            {
                _context.PoradniaTyp.Remove(poradniaTyp);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoradniaTypExists(int id)
        {
          return (_context.PoradniaTyp?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
