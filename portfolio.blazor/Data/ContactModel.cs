using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Blazor.Data
{
    public class ContactModel
    {
        [DisplayName("Email")]
        [EmailAddress]
        [Required]
        public string FromAddress { get; set; }
        [DisplayName("Name")]
        [MaxLength(100)]
        [Required]
        public string FromName { get; set; }
        [DisplayName("Subject")]
        [MaxLength(50)]
        [Required]
        public string Subject { get; set; }
        [DisplayName("Body")]
        [MaxLength(500)]
        [Required]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
    }
}
