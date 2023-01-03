using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Data.Data.Entities
{
    public class Uzytkownik 
    {
        [Key]
        public int IdUzytkownika { get; set; }

        [PersonalData]
        [Required(ErrorMessage = "Wpisz swoje imię")]
        [StringLength(50, ErrorMessage = "Imie może mieć maksymalnie 150 znaków.")]
        [Display(Name = "Imię")]
        public string? Imie { get; set; }

        [PersonalData]
        [Required(ErrorMessage = "Wpisz swoje nazwisko")]
        [StringLength(70, ErrorMessage = "Naziwsko może mieć maksymalnie 150 znaków.")]
        [Display(Name = "Nazwisko")]
        public string? Nazwisko { get; set; }

        [PersonalData]
        [Required(ErrorMessage = "Wprowadź swoją datę urodzenia")]
        [Display(Name = "Data urodzin")]
        public DateTime DataUrodzenia { get; set; }

        [PersonalData]
        [Required(ErrorMessage = "Wprowadź swój numer PESEL")]
        [StringLength(11, ErrorMessage = ("Pesel może mieć maksymalnie 11 znaków."))]
        [Display(Name = "PESEL")]
        public string? NumerPESEL { get; set; }
        public string UserId { get; set; }

        public int PlecId { get; set; }
        public virtual Plec? Plec { get; set; }

        public int AdresId { get; set; }
        public virtual Adres? Adres { get; set; }
        public virtual ICollection<Wizyty>? Wizyty { get; set; }
    }
}
