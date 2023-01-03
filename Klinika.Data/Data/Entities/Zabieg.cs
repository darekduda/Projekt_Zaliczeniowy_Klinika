using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Data.Data.Entities
{
    public class Zabieg
    {
        [Key]
        public int IdZabiegu { get; set; }
        public string? Nazwa { get; set; }
        public string? Opis { get; set; }
        public double Cena { get; set; }
        public string? Przeciwwskazania { get; set; }
        public string? Przygotowania { get; set; }
        public TimeSpan CzasTrwania { get; set; }
        public bool CzyAktywny { get; set; }
        public virtual ICollection<Wizyty>? Wizyty { get; set; }


    }
}
