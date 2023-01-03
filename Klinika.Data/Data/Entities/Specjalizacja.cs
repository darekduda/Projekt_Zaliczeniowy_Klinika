using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Data.Data.Entities
{
    public class Specjalizacja
    {
        [Key]
        public int IdSpecjalizacja { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Nazwa { get; set; }

        [MaxLength(1000)]
        public string? Opis { get; set; }
        public bool CzyAktywna { get; set; }

        public virtual ICollection<Lekarz>? Lekarz { get; set; }


    }
}
