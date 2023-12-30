using System.ComponentModel.DataAnnotations;

namespace Proje.ViewModel
{
    public class ViewUsers
    {

        // [Required] özniteliği kaldırıldı
        [MinLength(11, ErrorMessage = "TC 11 karakter olmalidir.")]
        [MaxLength(11, ErrorMessage = "TC 11 karakter olmalidir.")]
        public string KullaniciTC { get; set; }

        // [Required] özniteliği kaldırıldı
        [StringLength(30, ErrorMessage = "Username 30 karateri geçemez.")]
        public string KullaniciAdi { get; set; }

        [StringLength(30, ErrorMessage = "kullanici mail 50 karateri geçemez.")]
        [EmailAddress]
        public string KullaniciMail { get; set; }

        [MinLength(3, ErrorMessage = "Sifre en az 6 karakter olmalidir.")]
        [MaxLength(16, ErrorMessage = "Sifre en fazla 16 karakter olabilir.")]
        public string KullaniciSifre { get; set; }
    }
}
