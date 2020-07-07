using System.Threading.Tasks;
using Portfolio.Models;

namespace Portfolio.Services
{
    public interface IEmailService
    {
        Task SendAsync(Email email);
    }
}