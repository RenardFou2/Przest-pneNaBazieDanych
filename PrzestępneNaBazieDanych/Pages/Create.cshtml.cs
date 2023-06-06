using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PrzestępneNaBazieDanych.Data;
using PrzestępneNaBazieDanych.Models;

namespace PrzestępneNaBazieDanych.Pages
{
    public class CreateModel : PageModel
    {
        private readonly PrzestępneNaBazieDanych.Data.ApplicationDbContext _context;

        public CreateModel(PrzestępneNaBazieDanych.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Przestepne Przestepne { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Przestepne == null || Przestepne == null)
            {
                return Page();
            }

            _context.Przestepne.Add(Przestepne);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
