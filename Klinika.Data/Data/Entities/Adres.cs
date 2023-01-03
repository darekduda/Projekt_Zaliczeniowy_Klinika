using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Data.Data.Entities
{
    public class Adres
    {
        [Key]
        public int IdAdresu { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Miejscowosc { get; set; }
        [Required]
        public string? KodPocztowy { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Ulica { get; set; }
        [MaxLength(5)]
        public string? NumerDomu { get; set; }
        [MaxLength(3)]
        public string? NumerMieszkania { get; set; }
        public virtual ICollection<Uzytkownik>? Uzytkownik { get; set; }
        public virtual ICollection<Lekarz>? Lekarz { get; set; }

    }
}
