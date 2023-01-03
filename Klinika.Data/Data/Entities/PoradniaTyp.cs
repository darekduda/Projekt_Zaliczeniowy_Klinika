using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Data.Data.Entities
{
    public class PoradniaTyp
    {
        public int Id { get; set; }
        public string? Nazwa { get; set; }
        public virtual ICollection<Poradnia>? Poradnia { get; set; }

    }
}
