using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TheWorld.Models;
using TheWorld.Services;
using TheWorld.ViewModels;

namespace TheWorld.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMailService _mailService;
        private readonly IConfigurationRoot _config;
        private readonly IWorldRepository _repository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IMailService mailService, IConfigurationRoot config, IWorldRepository repository, ILogger<HomeController> logger)
        {
            _mailService = mailService;
            _config = config;
            _repository = repository;
            _logger = logger;
        }

        [Authorize]
        public IActionResult Trips()
        {
            var data = _repository.GetAllTrips();

            return View(data);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Trap()
        {
            throw new InvalidOperationException("Shysh vam!");
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel vm)
        {
            if (vm.Email.EndsWith("aol.com")) ModelState.AddModelError("", "We do not support AOL addresses");
            if (ModelState.IsValid)
            {
                _mailService.SendMail(_config["MailSettings:ToAddress"], vm.Email, $"Message from {vm.Name}", vm.Message);
                ModelState.Clear();
                ViewBag.UserMessage = "Message sent!";
            }
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
