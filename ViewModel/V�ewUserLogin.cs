using System.ComponentModel.DataAnnotations;

namespace Proje.ViewModel
{
    public class VİewUsersLogin
    {
        [StringLength(30, ErrorMessage = "kullanici mail 50 karateri geçemez.")]
        [EmailAddress]
        public string KullaniciMail { get; set; }

        [MinLength(3, ErrorMessage = "Sifre en az 6 karakter olmalidir.")]
        [MaxLength(16, ErrorMessage = "Sifre en fazla 16 karakter olabilir.")]
        public string KullaniciSifre { get; set; }
    }
}
