using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Data.Data.CMS
{
    public class GeneralGallery
    {
        [Key]
        public int IdGeneralGallery { get; set; }

        [Required(ErrorMessage = "Wpisz nazwe")]
        [MaxLength(50, ErrorMessage = "Nazwa powinien zawierać max 30 znaków")]
        [Display(Name = "Nazwa")]
        public string? Nazwa { get; set; }
        public string? imgPath { get; set; }
        public bool CzyAktywny { get; set; }
    }
}
