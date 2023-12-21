using System.ComponentModel.DataAnnotations;

namespace Proje.Models.siniflar
{
    public class Iletisim1
    {
        [Key]
        public int IletisimID { get; set; }
        public string Aciklama { get; set; }
        public string Mail { get; set; }
        public string Adres {  get; set; }
        public string Telefon { get; set; }
        public string Harita { get; set; }
        public bool Status { get; set; }
    }
}
