using System.ComponentModel.DataAnnotations;

namespace Proje.Models.siniflar
{
    public class Hakkimizda
    {
        [Key]
        public int Hakkımızda1ID { get; set; }
        public string Baslik1 { get; set; }
        public string Aciklama1 { get; set; }
        public string Image1 {  get; set; }
        public string Baslik2 { get; set; }
        public string Aciklama2 { get; set; }
       
      
        public string Baslik3 { get; set; }
        public string Baslik4 { get; set; }
        public string Aciklama3 { get; set; }
        public string Image2{ get; set; }

    }
}
