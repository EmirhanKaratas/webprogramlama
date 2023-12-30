using System.ComponentModel.DataAnnotations;

namespace Proje.Models.siniflar
{
    public class Iletisim
    {
        [Key]
        public int IletisimID { get; set; }
        public string Aciklama { get; set; }
        public string Mail { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Harita { get; set; }
        public string AdSoyad { get; set; }
        public string EMail { get; set; }
        public string Konu { get; set; }
        public string Mesaj { get; set; }

    }
}
