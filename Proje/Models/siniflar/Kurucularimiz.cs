using System.ComponentModel.DataAnnotations;

namespace Proje.Models.siniflar
{
    public class Kurucularimiz
    {
        [Key]
        public int KurucularimizId { get; set; }
        public string KurucuAd { get; set; }
        public string Aciklama { get; set; }
        public string Image { get; set; }
        public string TwitterUrl { get;}
        public string InstagramUrl { get; set; }
        public bool Status { get; set; }
    }
}
