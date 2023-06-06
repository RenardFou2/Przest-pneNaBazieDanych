using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(PrzestępneNaBazieDanych.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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
                var user = _userManager.GetUserAsync(User);
                var ID = _userManager.GetUserId(HttpContext.User);
                var login = _userManager.GetUserName(HttpContext.User);

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
