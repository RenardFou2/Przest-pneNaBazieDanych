using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrzestępneNaBazieDanych.Data;
using PrzestępneNaBazieDanych.Interface;
using PrzestępneNaBazieDanych.Models;

namespace PrzestępneNaBazieDanych.Pages
{
    public class historyModel : PageModel
    {

        private readonly ILogger<historyModel> _logger;
        private readonly LeapYearInterface _LYService;
        public historyModel(ILogger<historyModel> logger, LeapYearInterface LYService)
        {
            _logger = logger;
            _LYService = LYService;
        }

        public IList<Przestepne> PrzestepneLata { get; set; }
        public IList<Przestepne> PrzestepneLataPosortowane { get; set; }
        public void OnGet()
        {
            PrzestepneLataPosortowane = _LYService.WczytajPosortowane();
        }
    }
}
