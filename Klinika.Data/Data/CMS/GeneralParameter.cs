using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Klinika.Data.Data.CMS
{
    public class GeneralParameter
    {
        [Key]
        public int IdGeneralParametr { get; set; }

        [Required(ErrorMessage = "Wpisz nazwe")]
        [MaxLength(50, ErrorMessage = "Nazwa powinien zawierać max 30 znaków")]
        [Display(Name = "Nazwa")]
        public string? Nazwa { get; set; }

        [Required(ErrorMessage = "Wpisz opis")]
        [Display(Name = "Opis")]
        public string? Opis { get; set; }
        public bool CzyAktywny { get; set; }
    }
}
