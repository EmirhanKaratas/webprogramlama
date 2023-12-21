using System.ComponentModel.DataAnnotations;

namespace Proje.Models.siniflar
{
    public class Hakkimizda2
    {
        [Key]
        public int Hakkımızda2ID { get; set; }
        public string Baslik1 {  get; set; }
        public string Baslik2 { get; set; }
        public string Aciklama { get; set; }
        public string Image { get; set; }

    }
}
