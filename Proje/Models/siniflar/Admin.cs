using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proje.Models.siniflar
{
    [Table("Admins")]

    public class Admin
    {
        [Key]
        public long AdminID { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string AdminMail { get; set; }

        [Required]
        [StringLength(50)]
        public string AdminSifre { get; set; }

        [Required]
        [StringLength(50)]
        public string Rol { get; set; } = "admin";
    }
}
