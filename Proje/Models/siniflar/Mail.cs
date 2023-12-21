using System.ComponentModel.DataAnnotations;

namespace Proje.Models.siniflar
{
    public class Mail
    {
        [Key]
        public int MailID { get; set; }
        public string MailName { get; set; }

    }
}
