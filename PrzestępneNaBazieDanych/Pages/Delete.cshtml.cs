using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PrzestępneNaBazieDanych.Data;
using PrzestępneNaBazieDanych.Models;

namespace PrzestępneNaBazieDanych.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly PrzestępneNaBazieDanych.Data.ApplicationDbContext _context;

        public DeleteModel(PrzestępneNaBazieDanych.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Przestepne == null)
            {
                return NotFound();
            }
            var przestepne = await _context.Przestepne.FindAsync(id);

            if (przestepne != null)
            {
                Przestepne = przestepne;
                _context.Przestepne.Remove(Przestepne);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
