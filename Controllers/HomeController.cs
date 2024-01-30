using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SessionExample.Models;
using System.Diagnostics;

namespace SessionExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetName(string name)
        {
            HttpContext.Session.SetString("UserName", name);

            return RedirectToAction("ShowName");
        }


        public IActionResult ShowName()
        {
            string userName = HttpContext.Session.GetString("UserName");

            ViewBag.UserName = userName;

            return View();
        }

        public IActionResult Privacy()
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
