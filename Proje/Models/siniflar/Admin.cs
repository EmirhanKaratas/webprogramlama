using System.ComponentModel.DataAnnotations;

namespace Proje.Models.siniflar
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        public string Kullanici { get; set; }
        public string Sifre {  get; set; }
    }
}
