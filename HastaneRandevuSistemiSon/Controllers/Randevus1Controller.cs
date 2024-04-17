using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HastaneRandevuSistemiSon.Data;
using HastaneRandevuSistemiSon.Models;
using HastaneRandevuSistemiSon.Services;

namespace HastaneRandevuSistemiSon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Randevus1Controller : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private LanguageService _localization;

        public Randevus1Controller(ApplicationDbContext context, LanguageService localization)
        {
            _context = context;
            LanguageService _localization;
        }

        // GET: api/Randevus1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Randevu>>> GetRandevus()
        {
          if (_context.Randevus == null)
          {
              return NotFound();
          }
            return await _context.Randevus.ToListAsync();
        }

        
    }
}
