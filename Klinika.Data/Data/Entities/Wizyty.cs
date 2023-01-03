using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Data.Data.Entities
{
    public class Wizyty
    {
        public int Id { get; set; }
        public int? PacjentId { get; set; }
        public int? LekarzId { get; set; }
        public int? ZabiegId { get; set; }
        public int? PoradniaId { get; set; }
        public DateTime DataWizyty { get; set; }
        public Uzytkownik? Uzytkownik { get; set; }
        public Lekarz? Lekarz { get; set; }
        public Zabieg? Zabieg { get; set; }
        public Poradnia? Poradnia { get; set; }
    }
}
