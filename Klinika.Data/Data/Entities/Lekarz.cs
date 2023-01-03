using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Data.Data.Entities
{
    public class Lekarz
    {
        public int Id { get; set; }

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

        public int PlecId { get; set; }
        public virtual Plec? Plec { get; set; }

        public int AdresId { get; set; }
        public virtual Adres? Adres { get; set; }

        public int TytulNaukowyId { get; set; }
        public virtual TytulNaukowy? TytulNaukowy { get; set; }

        public int SpecjalizacjaId { get; set; }
        public virtual Specjalizacja? Specjalizacja { get; set; }

        public int? PoradniaId { get; set; }
        public virtual Poradnia? Poradnia { get; set; }
        public virtual ICollection<Wizyty>? Wizyty { get; set; }

    }
}
