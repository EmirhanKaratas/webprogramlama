using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proje.Models.siniflar
{
    public class Güzergah
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GüzergahId { get; set; }

        public string Sehirler { get; set; }
       


    }
}
