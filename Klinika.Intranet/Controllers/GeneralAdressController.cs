using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Klinika.Data.Data;
using Klinika.Data.Data.CMS;
using Microsoft.AspNetCore.Authorization;

namespace Klinika.Intranet.Controllers
{
    [Authorize]
    public class GeneralAdressController : Controller
    {
        private readonly KlinikaContext _context;

        public GeneralAdressController(KlinikaContext context)
        {
            _context = context;
        }

        // GET: GeneralAdress
        public async Task<IActionResult> Index()
        {
              return _context.GeneralAdress != null ? 
                          View(await _context.GeneralAdress.ToListAsync()) :
                          Problem("Entity set 'KlinikaContext.GeneralAdress'  is null.");
        }

        // GET: GeneralAdress/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GeneralAdress == null)
            {
                return NotFound();
            }

            var generalAdress = await _context.GeneralAdress
                .FirstOrDefaultAsync(m => m.IdAdresu == id);
            if (generalAdress == null)
            {
                return NotFound();
            }

            return View(generalAdress);
        }

        // GET: GeneralAdress/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GeneralAdress/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAdresu,Miasto,Ulica,KodPocztowy,Numer,PozycjaWyswietlania,CzyAktywny")] GeneralAdress generalAdress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(generalAdress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(generalAdress);
        }

        // GET: GeneralAdress/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GeneralAdress == null)
            {
                return NotFound();
            }

            var generalAdress = await _context.GeneralAdress.FindAsync(id);
            if (generalAdress == null)
            {
                return NotFound();
            }
            return View(generalAdress);
        }

        // POST: GeneralAdress/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAdresu,Miasto,Ulica,KodPocztowy,Numer,PozycjaWyswietlania,CzyAktywny")] GeneralAdress generalAdress)
        {
            if (id != generalAdress.IdAdresu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(generalAdress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeneralAdressExists(generalAdress.IdAdresu))
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
            return View(generalAdress);
        }

        // GET: GeneralAdress/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GeneralAdress == null)
            {
                return NotFound();
            }

            var generalAdress = await _context.GeneralAdress
                .FirstOrDefaultAsync(m => m.IdAdresu == id);
            if (generalAdress == null)
            {
                return NotFound();
            }

            return View(generalAdress);
        }

        // POST: GeneralAdress/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GeneralAdress == null)
            {
                return Problem("Entity set 'KlinikaContext.GeneralAdress'  is null.");
            }
            var generalAdress = await _context.GeneralAdress.FindAsync(id);
            if (generalAdress != null)
            {
                _context.GeneralAdress.Remove(generalAdress);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GeneralAdressExists(int id)
        {
          return (_context.GeneralAdress?.Any(e => e.IdAdresu == id)).GetValueOrDefault();
        }
    }
}
