using restauracjaTI.Models.DbModels;
using System.Data.Entity;

namespace restauracjaTI.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("restauracjaTIConnectionString")
        {

        }

        public DbSet<Danie> Dania { get; set; }
        public DbSet<Zamowienie> Zamowienia { get; set; }
        public DbSet<RodzajDania> RodzajDan { get; set; }
        public DbSet<Klient> Klienci { get; set; }
        public DbSet <SzczegolyZamowienia> SzczegolyZamowien { get; set; }

    }
}