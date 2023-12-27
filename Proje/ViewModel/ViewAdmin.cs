using System.ComponentModel.DataAnnotations;

namespace Proje.ViewModel
{
    public class ViewAdmin
    {
        public Guid AdminID { get; set; } //benzersin olması için guid kullanıldı

        [Required]
        [StringLength(30)]
        [EmailAddress]
        public string KullaniciMail { get; set; }

        [Required]
        [StringLength(50)]
        public string Sifre { get; set; }

    }
}
