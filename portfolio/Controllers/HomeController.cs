using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Portfolio.Models;
using Portfolio.Services;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IEmailService EmailService { get; }
        public IConfiguration Configuration { get; }

        public HomeController(ILogger<HomeController> logger, IEmailService emailService, IConfiguration configuration)
        {
            _logger = logger;
            EmailService = emailService;
            Configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index() => View();

        [Route("Resume")]
        [HttpGet]
        public IActionResult Resume() => View();

        [Route("Contact")]
        [HttpGet]
        public IActionResult Contact() => View(new ContactViewModel());

        [Route("ContactSuccess")]
        [HttpGet]
        public IActionResult ContactSuccess() => View();

        [Route("Contact")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(ContactViewModel model)
        {
            var email = new Email();
            var fromAddress = new EmailAddress(model.FromAddress) { Name = model.FromName };
            var toAddress = new EmailAddress(Configuration.GetValue<string>("EmailAddress"));
            email.From.Add(toAddress);
            email.ReplyTo.Add(fromAddress);
            email.To.Add(toAddress);
            email.Subject = model.Subject;
            email.Body = $"{model.FromName}{Environment.NewLine}{model.FromAddress}{Environment.NewLine}{model.Body}";

            await EmailService.SendAsync(email);

            return RedirectToAction(nameof(ContactSuccess));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
