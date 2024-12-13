using Microsoft.EntityFrameworkCore;
using PizzeriaAPI.Models.Entities;

namespace PizzeriaAPI.Data
{
    public class PizzeriaContext : DbContext
    {
        public PizzeriaContext(DbContextOptions<PizzeriaContext> options) : base(options) { }

        public DbSet<Menu> Menu { get; set; }
        public DbSet<Użytkownicy> Użytkownicy { get; set; }
        public DbSet<Zamówienia> Zamówienia { get; set; }
        public DbSet<Towary> Towary { get; set; }
        public DbSet<Magazyn> Magazyn { get; set; }
        public DbSet<Faktury> Faktury { get; set; }
        public DbSet<Pracownicy> Pracownicy { get; set; }
        public DbSet<PrzepisyKulinarne> PrzepisyKulinarne { get; set; }
        public DbSet<Dostawcy> Dostawcy { get; set; }
        public DbSet<ZamówieniaFirmowe> ZamówieniaFirmowe { get; set; }
        public DbSet<Kontakt> Kontakt { get; set; }
    }
}