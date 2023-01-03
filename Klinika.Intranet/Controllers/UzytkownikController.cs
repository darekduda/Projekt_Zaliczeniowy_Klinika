using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Klinika.Data.Data;
using Klinika.Data.Data.Entities;
using Klinika.Intranet.Data;

namespace Klinika.Intranet.Controllers
{
    public class UzytkownikController : Controller
    {
        private readonly KlinikaContext _context;
        private readonly ApplicationDbContext _contextUsers;


        public UzytkownikController(KlinikaContext context, ApplicationDbContext contextUsers)
        {
            _context = context;
            _contextUsers = contextUsers;
        }

        // GET: Uzytkownik
        public async Task<IActionResult> Index()
        {
            var klinikaContext = _context.Uzytkownik.Include(u => u.Adres).Include(u => u.Plec);
            return View(await klinikaContext.ToListAsync());
        }

        // GET: Uzytkownik/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Uzytkownik == null)
            {
                return NotFound();
            }

            var uzytkownik = await _context.Uzytkownik
                .Include(u => u.Adres)
                .Include(u => u.Plec)
                .FirstOrDefaultAsync(m => m.IdUzytkownika == id);
            if (uzytkownik == null)
            {
                return NotFound();
            }

            return View(uzytkownik);
        }

        // GET: Uzytkownik/Create
        public IActionResult Create()
        {
            ViewData["AdresId"] = new SelectList(_context.Adres, "IdAdresu", "KodPocztowy");
            ViewData["PlecId"] = new SelectList(_context.Plec, "IdPlec", "IdPlec");
            ViewData["UserId"] = new SelectList(_contextUsers.Users, "UserId", "UserName");
            return View();
        }

        // POST: Uzytkownik/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUzytkownika,Imie,Nazwisko,DataUrodzenia,NumerPESEL,PlecId,AdresId")] Uzytkownik uzytkownik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uzytkownik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdresId"] = new SelectList(_context.Adres, "IdAdresu", "KodPocztowy", uzytkownik.AdresId);
            ViewData["PlecId"] = new SelectList(_context.Plec, "IdPlec", "IdPlec", uzytkownik.PlecId);
            ViewData["Uzytkownicy"] = new SelectList(_contextUsers.Users, "UserId", "UserName", uzytkownik.UserId );

            return View(uzytkownik);
        }

        // GET: Uzytkownik/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Uzytkownik == null)
            {
                return NotFound();
            }

            var uzytkownik = await _context.Uzytkownik.FindAsync(id);
            if (uzytkownik == null)
            {
                return NotFound();
            }
            ViewData["AdresId"] = new SelectList(_context.Adres, "IdAdresu", "KodPocztowy", uzytkownik.AdresId);
            ViewData["PlecId"] = new SelectList(_context.Plec, "IdPlec", "IdPlec", uzytkownik.PlecId);
            return View(uzytkownik);
        }

        // POST: Uzytkownik/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUzytkownika,Imie,Nazwisko,DataUrodzenia,NumerPESEL,PlecId,AdresId")] Uzytkownik uzytkownik)
        {
            if (id != uzytkownik.IdUzytkownika)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uzytkownik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UzytkownikExists(uzytkownik.IdUzytkownika))
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
            ViewData["AdresId"] = new SelectList(_context.Adres, "IdAdresu", "KodPocztowy", uzytkownik.AdresId);
            ViewData["PlecId"] = new SelectList(_context.Plec, "IdPlec", "IdPlec", uzytkownik.PlecId);
            return View(uzytkownik);
        }

        // GET: Uzytkownik/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Uzytkownik == null)
            {
                return NotFound();
            }

            var uzytkownik = await _context.Uzytkownik
                .Include(u => u.Adres)
                .Include(u => u.Plec)
                .FirstOrDefaultAsync(m => m.IdUzytkownika == id);
            if (uzytkownik == null)
            {
                return NotFound();
            }

            return View(uzytkownik);
        }

        // POST: Uzytkownik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Uzytkownik == null)
            {
                return Problem("Entity set 'KlinikaContext.Uzytkownik'  is null.");
            }
            var uzytkownik = await _context.Uzytkownik.FindAsync(id);
            if (uzytkownik != null)
            {
                _context.Uzytkownik.Remove(uzytkownik);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UzytkownikExists(int id)
        {
          return (_context.Uzytkownik?.Any(e => e.IdUzytkownika == id)).GetValueOrDefault();
        }
    }
}
