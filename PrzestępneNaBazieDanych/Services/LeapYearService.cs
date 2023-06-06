using Microsoft.EntityFrameworkCore;
using PrzestępneNaBazieDanych.Data;
using PrzestępneNaBazieDanych.Interface;
using PrzestępneNaBazieDanych.Models;
using System;

namespace PrzestępneNaBazieDanych.Services
{
    public class LeapYearService : LeapYearInterface
    {
        private readonly ApplicationDbContext _context;
        public LeapYearService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SauvegardeIntoDB(Przestepne item)
        {
            _context.Przestepne.Add(item);
            _context.SaveChanges();
        }

        public IList<Przestepne> WczytajPosortowane()
        {
            IList<Przestepne>  PrzestepneLata = _context.Przestepne.ToList();
            return PrzestepneLata.OrderByDescending(o => o.Date).ToList();
        }

        public IList<Przestepne> GetPrzestepne()
        {
            return _context.Przestepne.ToList();
        }

    }
}
