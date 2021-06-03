using System.ComponentModel.DataAnnotations;

namespace email.Models
{
    public class MailAddress
    {
        [Required]
        [EmailAddress]
        public string Address { get; set; }
    }
}