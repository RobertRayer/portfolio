using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Portfolio.Services.Email.Models;

namespace Portfolio.Services.Email.Service
{
    public class EmailService : IEmailService
    {
        public EmailService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private EmailOptions EmailOptions { get; set; }
        private IConfiguration Configuration { get; }

        public async Task SendAsync(EmailMessage email)
        {
            if (EmailOptions == null)
                InitializeOptions();

            var message = new MimeMessage();
            message.From.AddRange(email.From.ToMailboxAddress());
            message.ReplyTo.AddRange(email.ReplyTo.ToMailboxAddress());
            message.To.AddRange(email.To.ToMailboxAddress());
            message.Subject = email.Subject;            
            message.Body = new TextPart("plain")
            {
                Text = email.Body
            };

            using var client = new SmtpClient();
            client.Connect(EmailOptions.Server, EmailOptions.Port, true);
            client.Authenticate(EmailOptions.Username, EmailOptions.Password);
            await client.SendAsync(message);
            client.Disconnect(true);
        }

        private void InitializeOptions()
        {
            EmailOptions = new EmailOptions
            {
                EmailAddress = Configuration.GetValue<string>("EmailAddress"),
                Password = Configuration.GetValue<string>("EmailPassword"),
                Port = Configuration.GetValue<int>("EmailPort"),
                Server = Configuration.GetValue<string>("EmailServer"),
                Username = Configuration.GetValue<string>("EmailUsername")
            };
        }
    }
}
