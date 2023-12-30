using System.ComponentModel.DataAnnotations;

namespace Proje.ViewModel
{
    public class ViewGuzergahEkle
    {
        [Required]
        public string Sehirler { get; set; }

        public int GuzergahId { get; set; }
    }
}
