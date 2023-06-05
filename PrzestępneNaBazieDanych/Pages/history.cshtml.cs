using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrzestępneNaBazieDanych.Data;
using PrzestępneNaBazieDanych.Models;

namespace PrzestępneNaBazieDanych.Pages
{
    public class historyModel : PageModel
    {

        private readonly ILogger<historyModel> _logger;
        private readonly ApplicationDbContext _context;
        public historyModel(ILogger<historyModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IList<Przestepne> PrzestepneLata { get; set; }
        public IList<Przestepne> PrzestepneLataPosortowane { get; set; }
        public void OnGet()
        {
            PrzestepneLata = _context.Przestepne.ToList();
            PrzestepneLataPosortowane = PrzestepneLata.OrderByDescending(o => o.Date).ToList();
        }
    }
}
