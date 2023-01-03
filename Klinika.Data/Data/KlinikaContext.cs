using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Data.Data
{
    public class KlinikaContext : DbContext
    {
        public KlinikaContext(DbContextOptions<KlinikaContext> options)
            : base(options)
        {
        }

        public DbSet<Klinika.Data.Data.CMS.GeneralParameter> GeneralParameter { get; set; }

        public DbSet<Klinika.Data.Data.CMS.OpeningHours> OpeningHours { get; set; }

        public DbSet<Klinika.Data.Data.CMS.GeneralContact> GeneralContact { get; set; }

        public DbSet<Klinika.Data.Data.CMS.GeneralAdress> GeneralAdress { get; set; }
        public DbSet<Klinika.Data.Data.CMS.GeneralGallery> GeneralGallery { get; set; }
        public DbSet<Klinika.Data.Data.Entities.Adres> Adres { get; set; }
        public DbSet<Klinika.Data.Data.Entities.Lekarz> Lekarz { get; set; }
        public DbSet<Klinika.Data.Data.Entities.Plec> Plec { get; set; }
        public DbSet<Klinika.Data.Data.Entities.Poradnia> Poradnia { get; set; }
        public DbSet<Klinika.Data.Data.Entities.PoradniaTyp> PoradniaTyp { get; set; }
        public DbSet<Klinika.Data.Data.Entities.PoradniaZabieg> PoradniaZabieg { get; set; }
        public DbSet<Klinika.Data.Data.Entities.Specjalizacja> Specjalizacja { get; set; }
        public DbSet<Klinika.Data.Data.Entities.TytulNaukowy> TytulNaukowy { get; set; }
        public DbSet<Klinika.Data.Data.Entities.Uzytkownik> Uzytkownik { get; set; }
        public DbSet<Klinika.Data.Data.Entities.Zabieg> Zabieg { get; set; }
        public DbSet<Klinika.Data.Data.Entities.Wizyty> Wizyty { get; set; }

    }
}
