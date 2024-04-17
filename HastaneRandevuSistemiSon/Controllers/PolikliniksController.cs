using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HastaneRandevuSistemiSon.Data;
using HastaneRandevuSistemiSon.Models;
using Microsoft.AspNetCore.Authorization;
using HastaneRandevuSistemiSon.Services;

namespace HastaneRandevuSistemiSon.Controllers
{


    public class PolikliniksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private LanguageService _localization;

        public PolikliniksController(ApplicationDbContext context, LanguageService localization)
        {
            _context = context;
            _localization = localization;
        }

        public async Task<IActionResult> Index()
        {
              return _context.Polikliniks != null ? 
                          View(await _context.Polikliniks.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Polikliniks'  is null.");
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Polikliniks == null)
            {
                return NotFound();
            }

            var poliklinik = await _context.Polikliniks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (poliklinik == null)
            {
                return NotFound();
            }

            return View(poliklinik);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Isim")] Poliklinik poliklinik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(poliklinik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(poliklinik);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Polikliniks == null)
            {
                return NotFound();
            }

            var poliklinik = await _context.Polikliniks.FindAsync(id);
            if (poliklinik == null)
            {
                return NotFound();
            }
            return View(poliklinik);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Isim")] Poliklinik poliklinik)
        {
            if (id != poliklinik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(poliklinik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoliklinikExists(poliklinik.Id))
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
            return View(poliklinik);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Polikliniks == null)
            {
                return NotFound();
            }

            var poliklinik = await _context.Polikliniks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (poliklinik == null)
            {
                return NotFound();
            }

            return View(poliklinik);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Polikliniks == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Polikliniks'  is null.");
            }
            var poliklinik = await _context.Polikliniks.FindAsync(id);
            if (poliklinik != null)
            {
                _context.Polikliniks.Remove(poliklinik);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoliklinikExists(int id)
        {
          return (_context.Polikliniks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
