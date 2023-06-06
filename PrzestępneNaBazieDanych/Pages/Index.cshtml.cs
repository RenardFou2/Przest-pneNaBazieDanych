﻿using System;
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

        public IndexModel(PrzestępneNaBazieDanych.Data.ApplicationDbContext context, LeapYearInterface LYService)
        {
            _context = context;
            _LYService = LYService;
        }

        public IList<Przestepne> Przestepne { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Przestepne != null)
            {
                Przestepne = await _context.Przestepne.ToListAsync();
            }
        }
    }
}
