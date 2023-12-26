using System.ComponentModel.DataAnnotations;

namespace Proje.Models.siniflar
{
    public class Yorumlar
    {
        [Key]
        public int YorumlarID { get; set; }
        public string MusteriAdi {  get; set; }
        public string Mail {  get; set; }
        public string Yorum { get; set; }
        public string MusteriResim { get; set; }
       
        public bool Status { get; set; }
        
    }
}
