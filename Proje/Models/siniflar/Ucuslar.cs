using System.ComponentModel.DataAnnotations;

namespace Proje.Models.siniflar
{
    public class Ucuslar
    {
        [Key]
        public int UcuslarID { get; set; }
        public string City1 { get; set; }
        public string City2 { get; set; }
        public string Zaman { get; set; }
        public double Fiyat { get; set; }
        public string Image { get; set; }
        public string Aciklama { get; set; }
        public int Kapasite { get; set; }
        public bool Status { get; set; }
    }
}
