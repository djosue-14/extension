using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace email.Models
{
    public class Mail
    {
        [Required]
        [EmailAddress]
        public string From { get; set; }
        
        public List<MailAddress> To { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Subject { get; set; }

        public List<MailAddress> Cc { get; set; }

        public List<MailAddress> Bcc { get; set; }
        
        [MaxLength(10000)]
        public string Body { get; set; }
    }
}