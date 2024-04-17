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
    

    public class DoktorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private LanguageService _localization;

        public DoktorsController(ApplicationDbContext context, LanguageService localization)
        {
            _context = context;
            _localization = localization;
        }

       
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Doktors.Include(d => d.Birim);
            return View(await applicationDbContext.ToListAsync());
        }

       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Doktors == null)
            {
                return NotFound();
            }

            var doktor = await _context.Doktors
                .Include(d => d.Birim)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doktor == null)
            {
                return NotFound();
            }

            return View(doktor);
        }

        
        public IActionResult Create()
        {
            ViewData["BirimId"] = new SelectList(_context.Birims, "Id", "Isim");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Isim,SoyIsim,BirimId,PoliklinikId,Poliklinik")] Doktor doktor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doktor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BirimId"] = new SelectList(_context.Birims, "Id", "Isim", doktor.BirimId);
            return View(doktor);
        }

     
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Doktors == null)
            {
                return NotFound();
            }

            var doktor = await _context.Doktors.FindAsync(id);
            if (doktor == null)
            {
                return NotFound();
            }
            ViewData["BirimId"] = new SelectList(_context.Birims, "Id", "Isim", doktor.BirimId);
            return View(doktor);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Isim,SoyIsim,BirimId,PoliklinikId,Poliklinik")] Doktor doktor)
        {
            if (id != doktor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doktor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoktorExists(doktor.Id))
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
            ViewData["BirimId"] = new SelectList(_context.Birims, "Id", "Isim", doktor.BirimId);
            return View(doktor);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Doktors == null)
            {
                return NotFound();
            }

            var doktor = await _context.Doktors
                .Include(d => d.Birim)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doktor == null)
            {
                return NotFound();
            }

            return View(doktor);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Doktors == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Doktors'  is null.");
            }
            var doktor = await _context.Doktors.FindAsync(id);
            if (doktor != null)
            {
                _context.Doktors.Remove(doktor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoktorExists(int id)
        {
          return (_context.Doktors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
