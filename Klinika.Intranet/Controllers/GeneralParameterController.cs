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
    public class GeneralParameterController : Controller
    {
        private readonly KlinikaContext _context;

        public GeneralParameterController(KlinikaContext context)
        {
            _context = context;
        }

        // GET: GeneralParameter
        public async Task<IActionResult> Index()
        {
              return _context.GeneralParameter != null ? 
                          View(await _context.GeneralParameter.ToListAsync()) :
                          Problem("Entity set 'KlinikaContext.GeneralParameter'  is null.");
        }

        // GET: GeneralParameter/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GeneralParameter == null)
            {
                return NotFound();
            }

            var generalParameter = await _context.GeneralParameter
                .FirstOrDefaultAsync(m => m.IdGeneralParametr == id);
            if (generalParameter == null)
            {
                return NotFound();
            }

            return View(generalParameter);
        }

        // GET: GeneralParameter/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GeneralParameter/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGeneralParametr,Nazwa,Opis,CzyAktywny")] GeneralParameter generalParameter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(generalParameter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(generalParameter);
        }

        // GET: GeneralParameter/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GeneralParameter == null)
            {
                return NotFound();
            }

            var generalParameter = await _context.GeneralParameter.FindAsync(id);
            if (generalParameter == null)
            {
                return NotFound();
            }
            return View(generalParameter);
        }

        // POST: GeneralParameter/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGeneralParametr,Nazwa,Opis,CzyAktywny")] GeneralParameter generalParameter)
        {
            if (id != generalParameter.IdGeneralParametr)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(generalParameter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeneralParameterExists(generalParameter.IdGeneralParametr))
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
            return View(generalParameter);
        }

        // GET: GeneralParameter/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GeneralParameter == null)
            {
                return NotFound();
            }

            var generalParameter = await _context.GeneralParameter
                .FirstOrDefaultAsync(m => m.IdGeneralParametr == id);
            if (generalParameter == null)
            {
                return NotFound();
            }

            return View(generalParameter);
        }

        // POST: GeneralParameter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GeneralParameter == null)
            {
                return Problem("Entity set 'KlinikaContext.GeneralParameter'  is null.");
            }
            var generalParameter = await _context.GeneralParameter.FindAsync(id);
            if (generalParameter != null)
            {
                _context.GeneralParameter.Remove(generalParameter);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GeneralParameterExists(int id)
        {
          return (_context.GeneralParameter?.Any(e => e.IdGeneralParametr == id)).GetValueOrDefault();
        }
    }
}
