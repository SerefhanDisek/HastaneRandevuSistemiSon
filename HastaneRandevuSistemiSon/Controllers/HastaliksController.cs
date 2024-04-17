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
    

    public class HastaliksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private LanguageService _localization;

        public HastaliksController(ApplicationDbContext context, LanguageService localization)
        {
            _context = context;
            _localization = localization;
        }

    
        public async Task<IActionResult> Index()
        {
              return _context.Hastaliks != null ? 
                          View(await _context.Hastaliks.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Hastaliks'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hastaliks == null)
            {
                return NotFound();
            }

            var hastalik = await _context.Hastaliks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hastalik == null)
            {
                return NotFound();
            }

            return View(hastalik);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Isim,Tanim,Belirti")] Hastalik hastalik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hastalik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hastalik);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hastaliks == null)
            {
                return NotFound();
            }

            var hastalik = await _context.Hastaliks.FindAsync(id);
            if (hastalik == null)
            {
                return NotFound();
            }
            return View(hastalik);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Isim,Tanim,Belirti")] Hastalik hastalik)
        {
            if (id != hastalik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hastalik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HastalikExists(hastalik.Id))
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
            return View(hastalik);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hastaliks == null)
            {
                return NotFound();
            }

            var hastalik = await _context.Hastaliks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hastalik == null)
            {
                return NotFound();
            }

            return View(hastalik);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hastaliks == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Hastaliks'  is null.");
            }
            var hastalik = await _context.Hastaliks.FindAsync(id);
            if (hastalik != null)
            {
                _context.Hastaliks.Remove(hastalik);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HastalikExists(int id)
        {
          return (_context.Hastaliks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
