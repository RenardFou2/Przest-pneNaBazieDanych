using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrzestępneNaBazieDanych.Data;
using PrzestępneNaBazieDanych.Models;

namespace PrzestępneNaBazieDanych.Pages
{
    public class EditModel : PageModel
    {
        private readonly PrzestępneNaBazieDanych.Data.ApplicationDbContext _context;

        public EditModel(PrzestępneNaBazieDanych.Data.ApplicationDbContext context)
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

            var przestepne =  await _context.Przestepne.FirstOrDefaultAsync(m => m.Id == id);
            if (przestepne == null)
            {
                return NotFound();
            }
            Przestepne = przestepne;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Przestepne).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrzestepneExists(Przestepne.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PrzestepneExists(int id)
        {
          return (_context.Przestepne?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
