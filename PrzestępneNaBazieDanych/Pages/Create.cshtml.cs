using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PrzestępneNaBazieDanych.Data;
using PrzestępneNaBazieDanych.Interface;
using PrzestępneNaBazieDanych.Models;

namespace PrzestępneNaBazieDanych.Pages
{
    public class CreateModel : PageModel
    {
        private readonly LeapYearInterface _LYService;
        public CreateModel(LeapYearInterface LYService)
        {
            _LYService = LYService;
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
            if (ModelState.IsValid || Przestepne != null)
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
                _LYService.SauvegardeIntoDB(Przestepne);
            }
        }
    }
}
