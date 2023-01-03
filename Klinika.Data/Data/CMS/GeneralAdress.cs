using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Klinika.Data.Data.CMS
{
    public  class GeneralAdress
    {
        [Key]
        public int IdAdresu { get; set; }

        [Required(ErrorMessage = "Wpisz Miasto")]
        [Column(TypeName = "nvarchar(max)")]
        [Display(Name = "Miasto")]
        public string? Miasto { get; set; }

        [Required(ErrorMessage = "Wpisz ulice")]
        [Column(TypeName = "nvarchar(max)")]
        [Display(Name = "Ulica")]
        public string? Ulica { get; set; }

        [Required(ErrorMessage = "Wpisz kod pocztowy")]
        [Column(TypeName = "nvarchar(max)")]
        [StringLength(7)]
        [Display(Name = "Kod pocztowy")]
        public string? KodPocztowy { get; set; }

        [Required(ErrorMessage = "Wpisz numer domu / lokalu")]
        [Column(TypeName = "nvarchar(max)")]
        [Display(Name = "Numer")]
        public string? Numer { get; set; }

        [Required(ErrorMessage = "Wpisz pozycję na ktorej ma być wyświetlony")]
        [Display(Name = "Numer pozycji")]
        public int PozycjaWyswietlania { get; set; }

        [Required(ErrorMessage = "Zaznacz, czy ma być wyświetlony na stronie")]
        [Display(Name = "Czy widoczny?")]
        public bool CzyAktywny { get; set; }
    }
}
