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
        public string Result { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public void OnPost()
        {
          if (ModelState.IsValid || _context.Przestepne != null || Przestepne != null)
            {
                DateTime time = DateTime.Now;
                Przestepne.Date = time.ToString("dd/MM/yyyy HH:mm:ss");

                if (Przestepne.Year % 4 == 0 && (Przestepne.Year % 100 != 0 || Przestepne.Year % 400 == 0))
                {
                    Result = $"{Przestepne.Name} urodzili się w roku przestępnym.";
                    Przestepne.Result = "Przestępne";
                }
                else
                {
                    Result = $"{Przestepne.Name} NIE urodzili się w roku przestępnym.";
                    Przestepne.Result = "Nie przestępne";
                }
                _context.Przestepne.Add(Przestepne);
                _context.SaveChanges();
            }

        }
    }
}
