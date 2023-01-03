using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Data.Data.Entities
{
    public class PoradniaZabieg
    {
        public int Id { get; set; }
        public int IdPoradnia { get; set; }
        public int IdZabieg { get; set; }
        public decimal Cena { get; set; }


    }
}
