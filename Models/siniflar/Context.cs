
using Microsoft.EntityFrameworkCore;

namespace Proje.Models.siniflar
{
    public class Context : DbContext
    {
        public Context()
        {
        }
        public Context(DbContextOptions options) : base(options)
        { }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Güzergah> Güzergahs { get; set; }
        public DbSet<Hakkimizda> Hakkimizdas { get; set; }
        public DbSet<Iletisim> Iletisims { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Seferler> Seferlers { get; set; }
        public DbSet<Biletler>biletlers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                    .Property(u => u.KullaniciTC)
                    .ValueGeneratedNever(); // ID'nin otomatik oluşturulmasını engelle

            modelBuilder.Entity<Admin>()
                  .Property(u => u.AdminID)
                  .ValueGeneratedNever(); // ID'nin otomatik oluşturulmasını engelle

        }
    }
}
