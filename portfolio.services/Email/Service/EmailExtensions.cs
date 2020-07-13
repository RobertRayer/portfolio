using System.Collections.Generic;
using MimeKit;
using Portfolio.Services.Email.Models;

namespace Portfolio.Services.Email.Service
{
    public static class EmailExtensions
    {
        public static IEnumerable<MailboxAddress> ToMailboxAddress(this IEnumerable<EmailAddress> emails)
        {
            foreach (var email in emails)
            {
                if (string.IsNullOrEmpty(email.Name))                
                    yield return MailboxAddress.Parse(email.Address);                
                else                
                    yield return new MailboxAddress(email.Name, email.Address);                
            }
        }
    }
}
