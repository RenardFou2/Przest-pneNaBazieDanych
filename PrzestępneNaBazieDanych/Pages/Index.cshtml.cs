using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrzestępneNaBazieDanych.Data;
using PrzestępneNaBazieDanych.Interface;
using PrzestępneNaBazieDanych.Models;
using System;

namespace PrzestępneNaBazieDanych.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly LeapYearInterface _LYService;

        public IndexModel(ILogger<IndexModel> logger, LeapYearInterface LYService)
        {
            _logger = logger;
            _LYService = LYService;
        }

        public string Result { get; set; }

        [BindProperty]
        public Przestepne Przestepne { get; set; }
        public void OnPost()
        {
            DateTime time = DateTime.Now;
            Przestepne.Date = time.ToString("dd/MM/yyyy HH:mm:ss");

            if (ModelState.IsValid)
            {
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
                _LYService.SauvegardeIntoDB( Przestepne );
            }
        }
        public void OnGet()
        {
        }
    }
}