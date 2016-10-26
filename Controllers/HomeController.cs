using Microsoft.AspNetCore.Mvc;
using TheWorld.Services;
using TheWorld.ViewModels;

namespace TheWorld.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMailService _mailService;

        public HomeController(IMailService mailService)
        {
            _mailService = mailService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel vm)
        {
            _mailService.SendMail("borys.lebeda@gmail.com", vm.Email, $"Message from {vm.Name}", vm.Message);
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
