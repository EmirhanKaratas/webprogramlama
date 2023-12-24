
using Microsoft.EntityFrameworkCore;

namespace Proje.Models.siniflar
{
    public class Context:DbContext
    {
        

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       // {
         //   optionsBuilder.UseSqlServer("server=DESKTOP-1F5N2LM\\SQLEXPRESS;database=EUcakDB;integrated security=true;");
        //}
        public Context(DbContextOptions options) : base(options) 
        {

        }



        public DbSet<Admin> Admins { get; set; }
        public DbSet<Hakkimizda> Hakkimizdas { get; set; }
       
        public DbSet<Iletisim> Iletisims { get; set; }
       
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Kurucularımız> Kurucularımızs { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<Paylasim> Paylasims { get; set; }
        public DbSet<Ucuslar> Ucuslars { get; set; }
        public DbSet<Yorumlar> Yorumlars { get; set; }
    }
}
