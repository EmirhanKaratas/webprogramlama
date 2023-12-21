using System.ComponentModel.DataAnnotations;

namespace Proje.Models.siniflar
{
    public class Hakkimizda1
    {
        [Key]
        public int HakkımızdaID { get; set; }
        public string Baslik1 { get; set; }
        public string Aciklama1 { get; set; }
        public string Image1 {  get; set; }
        public string Baslik2 { get; set; }
        public string Aciklama2 { get; set; }
        public bool Status { get; set; }

    }
}
