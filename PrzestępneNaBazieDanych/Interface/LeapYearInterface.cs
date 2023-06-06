using Microsoft.EntityFrameworkCore;
using PrzestępneNaBazieDanych.Models;

namespace PrzestępneNaBazieDanych.Interface
{
    public interface LeapYearInterface
    {
        public void SauvegardeIntoDB(Przestepne item);
        public IList<Przestepne> WczytajPosortowane();
        public IList<Przestepne> GetPrzestepne();
    }
}
