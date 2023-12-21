
using Microsoft.EntityFrameworkCore;

namespace Proje.Models.siniflar
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-1F5N2LM;database=EUcakDB;integrated security=true;");

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Hakkimizda1> Hakkimizda1s { get; set; }
        public DbSet<Hakkimizda2> Hakkimizda2s { get; set; }
        public DbSet<Iletisim1> Iletisim1s { get; set; }
        public DbSet<Iletisim2> Iletisim2s { get; set; }
        public DbSet<Kurucularımız> Kurucularımızs { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<Paylasim> Paylasims { get; set; }
        public DbSet<Ucuslar> Ucuslars { get; set; }
        public DbSet<Yorumlar> Yorumlars { get; set; }
    }
}
