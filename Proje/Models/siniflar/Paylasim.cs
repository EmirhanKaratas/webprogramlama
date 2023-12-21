using System.ComponentModel.DataAnnotations;

namespace Proje.Models.siniflar
{
    public class Paylasim
    {
        [Key]
        public int PaylasimID { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }

    }
}
