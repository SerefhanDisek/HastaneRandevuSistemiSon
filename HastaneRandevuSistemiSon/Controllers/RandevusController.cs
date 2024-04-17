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
    [Authorize]
    public class RandevusController : Controller
    {
        private readonly ApplicationDbContext _context;
        private LanguageService _localization;

        public RandevusController(ApplicationDbContext context, LanguageService localization)
        {
            _context = context;
            _localization = localization;
        }


        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Randevus.Include(r => r.Doktor).Include(r => r.Hasta);
            return View(await applicationDbContext.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Randevus == null)
            {
                return NotFound();
            }

            var randevu = await _context.Randevus
                .Include(r => r.Doktor)
                .Include(r => r.Hasta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (randevu == null)
            {
                return NotFound();
            }

            return View(randevu);
        }


        public IActionResult Create()
        {
            ViewData["DoktorId"] = new SelectList(_context.Doktors, "Id", "Isim");
            ViewData["HastaId"] = new SelectList(_context.Hastas, "Id", "Isim");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,HastaId,DoktorId")] Randevu randevu)
        {
            ViewData["DoktorId"] = new SelectList(_context.Doktors, "Id", "Isim", randevu.DoktorId);
            ViewData["HastaId"] = new SelectList(_context.Hastas, "Id", "Isim", randevu.HastaId);
            _context.Add(randevu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
           
            
        }

        [Authorize(Roles ="seref")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Randevus == null)
            {
                return NotFound();
            }

            var randevu = await _context.Randevus.FindAsync(id);
            if (randevu == null)
            {
                return NotFound();
            }
            ViewData["DoktorId"] = new SelectList(_context.Doktors, "Id", "Isim", randevu.DoktorId);
            ViewData["HastaId"] = new SelectList(_context.Hastas, "Id", "Isim", randevu.HastaId);
            return View(randevu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,HastaId,DoktorId")] Randevu randevu)
        {
            if (id != randevu.Id)
            {
                return NotFound();
            }

            ViewData["DoktorId"] = new SelectList(_context.Doktors, "Id", "Isim", randevu.DoktorId);
            ViewData["HastaId"] = new SelectList(_context.Hastas, "Id", "Isim", randevu.HastaId);
            try
                {
                    _context.Update(randevu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RandevuExists(randevu.Id))
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

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Randevus == null)
            {
                return NotFound();
            }

            var randevu = await _context.Randevus
                .Include(r => r.Doktor)
                .Include(r => r.Hasta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (randevu == null)
            {
                return NotFound();
            }

            return View(randevu);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Randevus == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Randevus'  is null.");
            }
            var randevu = await _context.Randevus.FindAsync(id);
            if (randevu != null)
            {
                _context.Randevus.Remove(randevu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RandevuExists(int id)
        {
          return (_context.Randevus?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
