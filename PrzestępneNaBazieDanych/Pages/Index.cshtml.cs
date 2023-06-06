using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PrzestępneNaBazieDanych.Data;
using PrzestępneNaBazieDanych.Interface;
using PrzestępneNaBazieDanych.Models;

namespace PrzestępneNaBazieDanych.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PrzestępneNaBazieDanych.Data.ApplicationDbContext _context;
        private readonly LeapYearInterface _LYService;

        public IndexModel(LeapYearInterface LYService)
        {
            _LYService = LYService;
        }

        public IList<Przestepne> Przestepne { get;set; } = default!;

        public void OnGet()
        {
            Przestepne = _LYService.GetPrzestepne();
        }
    }
}
