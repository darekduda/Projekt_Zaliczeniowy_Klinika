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
    public class GeneralGalleryController : Controller
    {
        private readonly KlinikaContext _context;

        public GeneralGalleryController(KlinikaContext context)
        {
            _context = context;
        }

        // GET: GeneralGallery
        public async Task<IActionResult> Index()
        {
              return _context.GeneralGallery != null ? 
                          View(await _context.GeneralGallery.ToListAsync()) :
                          Problem("Entity set 'KlinikaContext.GeneralGallery'  is null.");
        }

        // GET: GeneralGallery/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GeneralGallery == null)
            {
                return NotFound();
            }

            var generalGallery = await _context.GeneralGallery
                .FirstOrDefaultAsync(m => m.IdGeneralGallery == id);
            if (generalGallery == null)
            {
                return NotFound();
            }

            return View(generalGallery);
        }

        // GET: GeneralGallery/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GeneralGallery/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGeneralGallery,Nazwa,imgPath,CzyAktywny")] GeneralGallery generalGallery)
        {
            if (ModelState.IsValid)
            {
                _context.Add(generalGallery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(generalGallery);
        }

        // GET: GeneralGallery/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GeneralGallery == null)
            {
                return NotFound();
            }

            var generalGallery = await _context.GeneralGallery.FindAsync(id);
            if (generalGallery == null)
            {
                return NotFound();
            }
            return View(generalGallery);
        }

        // POST: GeneralGallery/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGeneralGallery,Nazwa,imgPath,CzyAktywny")] GeneralGallery generalGallery)
        {
            if (id != generalGallery.IdGeneralGallery)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(generalGallery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeneralGalleryExists(generalGallery.IdGeneralGallery))
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
            return View(generalGallery);
        }

        // GET: GeneralGallery/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GeneralGallery == null)
            {
                return NotFound();
            }

            var generalGallery = await _context.GeneralGallery
                .FirstOrDefaultAsync(m => m.IdGeneralGallery == id);
            if (generalGallery == null)
            {
                return NotFound();
            }

            return View(generalGallery);
        }

        // POST: GeneralGallery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GeneralGallery == null)
            {
                return Problem("Entity set 'KlinikaContext.GeneralGallery'  is null.");
            }
            var generalGallery = await _context.GeneralGallery.FindAsync(id);
            if (generalGallery != null)
            {
                _context.GeneralGallery.Remove(generalGallery);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GeneralGalleryExists(int id)
        {
          return (_context.GeneralGallery?.Any(e => e.IdGeneralGallery == id)).GetValueOrDefault();
        }
    }
}
