using System.ComponentModel.DataAnnotations;

namespace Proje.Models.siniflar
{
    public class Iletisim2
    {
        [Key]
        public int Iletsim2ID { get; set; }
        public string AdSoyad { get; set; }
        public string Mail { get; set; }
        public string Konu { get; set; }
        public string Mesaj { get; set; }

    }
}
