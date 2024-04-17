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
    

    public class BirimsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private LanguageService _localization;

        public BirimsController(ApplicationDbContext context, LanguageService localization)
        {
            _context = context;
            _localization = localization;
        }


        public async Task<IActionResult> Index()
        {
              return _context.Birims != null ? 
                          View(await _context.Birims.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Birims'  is null.");
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Birims == null)
            {
                return NotFound();
            }

            var birim = await _context.Birims
                .FirstOrDefaultAsync(m => m.Id == id);
            if (birim == null)
            {
                return NotFound();
            }

            return View(birim);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Isim")] Birim birim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(birim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(birim);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Birims == null)
            {
                return NotFound();
            }

            var birim = await _context.Birims.FindAsync(id);
            if (birim == null)
            {
                return NotFound();
            }
            return View(birim);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Isim")] Birim birim)
        {
            if (id != birim.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(birim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BirimExists(birim.Id))
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
            return View(birim);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Birims == null)
            {
                return NotFound();
            }

            var birim = await _context.Birims
                .FirstOrDefaultAsync(m => m.Id == id);
            if (birim == null)
            {
                return NotFound();
            }

            return View(birim);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Birims == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Birims'  is null.");
            }
            var birim = await _context.Birims.FindAsync(id);
            if (birim != null)
            {
                _context.Birims.Remove(birim);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BirimExists(int id)
        {
          return (_context.Birims?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
