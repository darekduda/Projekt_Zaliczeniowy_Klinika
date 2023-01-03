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
    public class GeneralContactController : Controller
    {
        private readonly KlinikaContext _context;

        public GeneralContactController(KlinikaContext context)
        {
            _context = context;
        }

        // GET: GeneralContact
        public async Task<IActionResult> Index()
        {
              return _context.GeneralContact != null ? 
                          View(await _context.GeneralContact.ToListAsync()) :
                          Problem("Entity set 'KlinikaContext.GeneralContact'  is null.");
        }

        // GET: GeneralContact/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GeneralContact == null)
            {
                return NotFound();
            }

            var generalContact = await _context.GeneralContact
                .FirstOrDefaultAsync(m => m.IdKontaktu == id);
            if (generalContact == null)
            {
                return NotFound();
            }

            return View(generalContact);
        }

        // GET: GeneralContact/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GeneralContact/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKontaktu,TytułKontakt,NumerTelefonu,NazwaKontaktu,PozycjaWyswietlania,CzyAktywny")] GeneralContact generalContact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(generalContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(generalContact);
        }

        // GET: GeneralContact/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GeneralContact == null)
            {
                return NotFound();
            }

            var generalContact = await _context.GeneralContact.FindAsync(id);
            if (generalContact == null)
            {
                return NotFound();
            }
            return View(generalContact);
        }

        // POST: GeneralContact/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKontaktu,TytułKontakt,NumerTelefonu,NazwaKontaktu,PozycjaWyswietlania,CzyAktywny")] GeneralContact generalContact)
        {
            if (id != generalContact.IdKontaktu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(generalContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeneralContactExists(generalContact.IdKontaktu))
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
            return View(generalContact);
        }

        // GET: GeneralContact/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GeneralContact == null)
            {
                return NotFound();
            }

            var generalContact = await _context.GeneralContact
                .FirstOrDefaultAsync(m => m.IdKontaktu == id);
            if (generalContact == null)
            {
                return NotFound();
            }

            return View(generalContact);
        }

        // POST: GeneralContact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GeneralContact == null)
            {
                return Problem("Entity set 'KlinikaContext.GeneralContact'  is null.");
            }
            var generalContact = await _context.GeneralContact.FindAsync(id);
            if (generalContact != null)
            {
                _context.GeneralContact.Remove(generalContact);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GeneralContactExists(int id)
        {
          return (_context.GeneralContact?.Any(e => e.IdKontaktu == id)).GetValueOrDefault();
        }
    }
}
