using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proje.Models.siniflar
{
    public class Seferler
    {
        [Key]
        public int SeferlerId { get; set; }
        public string güzergah { get; set; }
        public DateTime Gün { get; set; }
        public string Saat { get; set; }
        public double Fiyat { get; set; }
        public string Image { get; set; }
        public int Kapasite { get; set; }

    }
}
