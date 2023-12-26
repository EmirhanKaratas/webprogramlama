
using Microsoft.EntityFrameworkCore;

namespace Proje.Models.siniflar
{
    public class Context:DbContext
    {
        public Context()
        {
        }
        public Context(DbContextOptions options) : base(options)
        { }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Hakkimizda> Hakkimizdas { get; set; }
        public DbSet<Iletisim> Iletisims { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Kurucularimiz> Kurucularimizs { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<Paylasim> Paylasims { get; set; }
        public DbSet<Ucuslar> Ucuslars { get; set; }
        public DbSet<Yorumlar> Yorumlars { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                    .Property(u => u.KullaniciTC)
                    .ValueGeneratedNever(); // ID'nin otomatik oluşturulmasını engelle
        }
    }
}
