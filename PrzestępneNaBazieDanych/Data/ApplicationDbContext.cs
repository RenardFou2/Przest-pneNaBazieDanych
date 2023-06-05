using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrzestępneNaBazieDanych.Models;
using System;

namespace PrzestępneNaBazieDanych.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Przestepne> Przestepne { get; set; }

    }
}