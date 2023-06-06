using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PrzestępneNaBazieDanych.Models
{
    public class Przestepne
    {
        public int Id { get; set; }

        [Display(Name = "Rok urodzenia")]
        [Required(ErrorMessage = "Pole {0} jest wymagane")]
        [Range(1850, 2022, ErrorMessage = "{0} musi znajdować się w przedziale od {1} do {2}")]
        public int Year { get; set; }

        [Display(Name = "Imię")]
        [StringLength(64, ErrorMessage = "{0} przekroczyło maksymalną wartość {1} znaków.")]
        public string? Name { get; set; }

        [Display(Name = "Data")]
        public string? Date { get; set; }

        [Display(Name = "Result")]
        public string? Result { get; set; }

        [Display(Name = "ID")]
        public string? IDofUser { get; set; }
        
        [Display(Name = "LOGIN")]
        public string? UserLogin { get; set; }

    }
}
