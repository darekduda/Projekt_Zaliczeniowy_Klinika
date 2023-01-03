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
    public class LekarzController : Controller
    {
        private readonly KlinikaContext _context;

        public LekarzController(KlinikaContext context)
        {
            _context = context;
        }

        // GET: Lekarz
        public async Task<IActionResult> Index()
        {
            var klinikaContext = _context.Lekarz.Include(l => l.Adres).Include(l => l.Plec).Include(l => l.Poradnia).Include(l => l.Specjalizacja).Include(l => l.TytulNaukowy);
            return View(await klinikaContext.ToListAsync());
        }

        // GET: Lekarz/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lekarz == null)
            {
                return NotFound();
            }

            var lekarz = await _context.Lekarz
                .Include(l => l.Adres)
                .Include(l => l.Plec)
                .Include(l => l.Poradnia)
                .Include(l => l.Specjalizacja)
                .Include(l => l.TytulNaukowy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lekarz == null)
            {
                return NotFound();
            }

            return View(lekarz);
        }

        // GET: Lekarz/Create
        public IActionResult Create()
        {
            ViewData["AdresId"] = new SelectList(_context.Adres, "IdAdresu", "KodPocztowy");
            ViewData["PlecId"] = new SelectList(_context.Plec, "IdPlec", "IdPlec");
            ViewData["PoradniaId"] = new SelectList(_context.Poradnia, "Id", "Id");
            ViewData["SpecjalizacjaId"] = new SelectList(_context.Specjalizacja, "IdSpecjalizacja", "Nazwa");
            ViewData["TytulNaukowyId"] = new SelectList(_context.TytulNaukowy, "IdTytułNaukowy", "IdTytułNaukowy");
            return View();
        }

        // POST: Lekarz/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Imie,Nazwisko,PlecId,AdresId,TytulNaukowyId,SpecjalizacjaId,PoradniaId")] Lekarz lekarz)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lekarz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdresId"] = new SelectList(_context.Adres, "IdAdresu", "KodPocztowy", lekarz.AdresId);
            ViewData["PlecId"] = new SelectList(_context.Plec, "IdPlec", "IdPlec", lekarz.PlecId);
            ViewData["PoradniaId"] = new SelectList(_context.Poradnia, "Id", "Id", lekarz.PoradniaId);
            ViewData["SpecjalizacjaId"] = new SelectList(_context.Specjalizacja, "IdSpecjalizacja", "Nazwa", lekarz.SpecjalizacjaId);
            ViewData["TytulNaukowyId"] = new SelectList(_context.TytulNaukowy, "IdTytułNaukowy", "IdTytułNaukowy", lekarz.TytulNaukowyId);
            return View(lekarz);
        }

        // GET: Lekarz/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lekarz == null)
            {
                return NotFound();
            }

            var lekarz = await _context.Lekarz.FindAsync(id);
            if (lekarz == null)
            {
                return NotFound();
            }
            ViewData["AdresId"] = new SelectList(_context.Adres, "IdAdresu", "KodPocztowy", lekarz.AdresId);
            ViewData["PlecId"] = new SelectList(_context.Plec, "IdPlec", "IdPlec", lekarz.PlecId);
            ViewData["PoradniaId"] = new SelectList(_context.Poradnia, "Id", "Id", lekarz.PoradniaId);
            ViewData["SpecjalizacjaId"] = new SelectList(_context.Specjalizacja, "IdSpecjalizacja", "Nazwa", lekarz.SpecjalizacjaId);
            ViewData["TytulNaukowyId"] = new SelectList(_context.TytulNaukowy, "IdTytułNaukowy", "IdTytułNaukowy", lekarz.TytulNaukowyId);
            return View(lekarz);
        }

        // POST: Lekarz/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Imie,Nazwisko,PlecId,AdresId,TytulNaukowyId,SpecjalizacjaId,PoradniaId")] Lekarz lekarz)
        {
            if (id != lekarz.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lekarz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LekarzExists(lekarz.Id))
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
            ViewData["AdresId"] = new SelectList(_context.Adres, "IdAdresu", "KodPocztowy", lekarz.AdresId);
            ViewData["PlecId"] = new SelectList(_context.Plec, "IdPlec", "IdPlec", lekarz.PlecId);
            ViewData["PoradniaId"] = new SelectList(_context.Poradnia, "Id", "Id", lekarz.PoradniaId);
            ViewData["SpecjalizacjaId"] = new SelectList(_context.Specjalizacja, "IdSpecjalizacja", "Nazwa", lekarz.SpecjalizacjaId);
            ViewData["TytulNaukowyId"] = new SelectList(_context.TytulNaukowy, "IdTytułNaukowy", "IdTytułNaukowy", lekarz.TytulNaukowyId);
            return View(lekarz);
        }

        // GET: Lekarz/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lekarz == null)
            {
                return NotFound();
            }

            var lekarz = await _context.Lekarz
                .Include(l => l.Adres)
                .Include(l => l.Plec)
                .Include(l => l.Poradnia)
                .Include(l => l.Specjalizacja)
                .Include(l => l.TytulNaukowy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lekarz == null)
            {
                return NotFound();
            }

            return View(lekarz);
        }

        // POST: Lekarz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lekarz == null)
            {
                return Problem("Entity set 'KlinikaContext.Lekarz'  is null.");
            }
            var lekarz = await _context.Lekarz.FindAsync(id);
            if (lekarz != null)
            {
                _context.Lekarz.Remove(lekarz);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LekarzExists(int id)
        {
          return (_context.Lekarz?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
