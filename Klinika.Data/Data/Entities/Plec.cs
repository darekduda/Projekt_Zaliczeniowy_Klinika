using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Data.Data.Entities
{
    public class Plec
    {
        [Key]
        public int IdPlec { get; set; }
        public string? Nazwa { get; set; }
        public string? Opis { get; set; }
        public bool CzyAktywna { get; set; }
        public virtual ICollection<Uzytkownik>? Uzytkownik { get; set; }
        public virtual ICollection<Lekarz>? Lekarz { get; set; }

    }
}
