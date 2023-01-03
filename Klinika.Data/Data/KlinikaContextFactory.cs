using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Data.Data
{
    internal class KlinikaContextFactory : IDesignTimeDbContextFactory<KlinikaContext>
    {
        public KlinikaContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<KlinikaContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Klinika.Intranet.Data;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new KlinikaContext(optionsBuilder.Options);
        }
    }
}
