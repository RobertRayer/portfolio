using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Blazor.Data
{
    public class ContactModel
    {
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [Required(ErrorMessage ="Email is required")]
        public string FromAddress { get; set; }
        [DisplayName("Name")]
        [MaxLength(100)]
        [Required(ErrorMessage = "Name is required")]
        public string FromName { get; set; }
        [DisplayName("Subject")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Subject is required")]
        public string Subject { get; set; }
        [DisplayName("Body")]
        [MaxLength(500)]
        [Required(ErrorMessage = "Body is required")]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
    }
}
