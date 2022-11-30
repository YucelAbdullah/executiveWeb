using executiveData;
using executiveWeb.Models;
using Microsoft.AspNetCore.Mvc;
using executiveWeb.Models;
using SixLabors.ImageSharp;
using System.Diagnostics;

namespace executiveWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration configuration;
        private readonly AppDbContext context;

        public HomeController(
            
            ILogger<HomeController> logger,
            IConfiguration configuration,
            AppDbContext context


            )
        {
            _logger = logger;
            this.configuration = configuration;
            this.context = context;
        }



        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ContactUs(ContactUsViewModel model)
        {
           // await emailService.SendAsync(
           //    configuration.GetValue<string>("EMailSettings:SenderEmail"),
           //     $"Ziyaretçi Mesajı ({model.Name}",
           //     $" Gönderen:\t\t{model.Name}\n Telefon:\t\t{model.PhoneNumber ?? "Telefon Belirtilmemiş"}\n Mesaj:\t\t{model.Email}\n {model.Message}"
           //     );
           // TempData["messageSend"] = true;
            return View(new ContactUsViewModel());
        }
        public IActionResult Projects()


        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Team()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}