using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proje.Models.siniflar
{
    [Table("Users")]
    public class Users
    {
        [Key]
        [Required]
        public string KullaniciTC { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string KullaniciAdi { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string KullaniciMail { get; set; }

        [Required]
        [StringLength(100)]
        public string KullaniciSifre { get; set; }

        [Required]
        public string Rol { get; set; } = "user";
    }
}

