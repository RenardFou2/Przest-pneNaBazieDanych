using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrzestępneNaBazieDanych.Data;
using PrzestępneNaBazieDanych.Models;

namespace PrzestępneNaBazieDanych.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;
        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
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

                _context.Przestepne.Add(Przestepne);
                _context.SaveChanges();
            }
        }
        public void OnGet()
        {
        }
    }
}