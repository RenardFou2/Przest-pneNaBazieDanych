using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PrzestępneNaBazieDanych.Data;
using PrzestępneNaBazieDanych.Models;
using Microsoft.Extensions.Configuration;


namespace PrzestępneNaBazieDanych.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PrzestępneNaBazieDanych.Data.ApplicationDbContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(PrzestępneNaBazieDanych.Data.ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }


        public PaginatedList<Przestepne> Przestepne { get; set; } = default!;

        public async Task OnGetAsync(string searchString, int? pageIndex)
        {
            if (searchString != null)
            {
                pageIndex = 1;
            }

            var pageSize = Configuration.GetValue("PageSize", 4);
            Przestepne = await PaginatedList<Przestepne>.CreateAsync(
                _context.Przestepne, pageIndex ?? 1, pageSize);
        }
    }
}
