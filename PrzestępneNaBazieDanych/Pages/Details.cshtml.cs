using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PrzestępneNaBazieDanych.Data;
using PrzestępneNaBazieDanych.Models;

namespace PrzestępneNaBazieDanych.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly PrzestępneNaBazieDanych.Data.ApplicationDbContext _context;

        public DetailsModel(PrzestępneNaBazieDanych.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Przestepne Przestepne { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Przestepne == null)
            {
                return NotFound();
            }

            var przestepne = await _context.Przestepne.FirstOrDefaultAsync(m => m.Id == id);
            if (przestepne == null)
            {
                return NotFound();
            }
            else 
            {
                Przestepne = przestepne;
            }
            return Page();
        }
    }
}
