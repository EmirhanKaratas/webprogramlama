using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proje.Models.siniflar
{
    [Table("Biletlers")]
    public class Biletler
    {
        [Key]
        public int Biletİd { get; set; }
        public string KullaniciTc { get; set; }  
    
        public string KullaniciEmail { get; set; }

        public string KullaniciAdi { get; set; }

        public string güzergah { get; set; }

        public string Gün {  get; set; }

        public string zaman {  get; set; } 
        
        public string koltuk {  get; set; }   
    }
}
