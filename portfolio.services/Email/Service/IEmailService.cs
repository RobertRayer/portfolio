using System.Threading.Tasks;
using Portfolio.Services.Email.Models;

namespace Portfolio.Services.Email.Service
{
    public interface IEmailService
    {
        Task SendAsync(EmailMessage email);
    }
}