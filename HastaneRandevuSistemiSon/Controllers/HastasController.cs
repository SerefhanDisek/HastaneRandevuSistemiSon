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

    public class HastasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private LanguageService _localization;

        public HastasController(ApplicationDbContext context, LanguageService localization)
        {
            _context = context;
            _localization = localization;
        }

        public async Task<IActionResult> Index()
        {
              return _context.Hastas != null ? 
                          View(await _context.Hastas.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Hastas'  is null.");
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hastas == null)
            {
                return NotFound();
            }

            var hasta = await _context.Hastas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hasta == null)
            {
                return NotFound();
            }

            return View(hasta);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Isim,SoyIsim,TelefonNumarasi,Email,DateofBirth")] Hasta hasta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hasta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hasta);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hastas == null)
            {
                return NotFound();
            }

            var hasta = await _context.Hastas.FindAsync(id);
            if (hasta == null)
            {
                return NotFound();
            }
            return View(hasta);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Isim,SoyIsim,TelefonNumarasi,Email,DateofBirth")] Hasta hasta)
        {
            if (id != hasta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hasta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HastaExists(hasta.Id))
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
            return View(hasta);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hastas == null)
            {
                return NotFound();
            }

            var hasta = await _context.Hastas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hasta == null)
            {
                return NotFound();
            }

            return View(hasta);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hastas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Hastas'  is null.");
            }
            var hasta = await _context.Hastas.FindAsync(id);
            if (hasta != null)
            {
                _context.Hastas.Remove(hasta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HastaExists(int id)
        {
          return (_context.Hastas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
