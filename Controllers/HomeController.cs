using Microsoft.AspNetCore.Mvc;
using TheWorld.ViewModels;

namespace TheWorld.Controllers
{
    public class HomeController : Controller
    {
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
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
