using System.Collections.Generic;

namespace Portfolio.Services.Email.Models
{
    public class EmailMessage
    {
        public IList<EmailAddress> From { get; set; } = new List<EmailAddress>();
        public IList<EmailAddress> To { get; set; } = new List<EmailAddress>();
        public IList<EmailAddress> ReplyTo { get; set; } = new List<EmailAddress>();
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
