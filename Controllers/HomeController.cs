using Microsoft.AspNetCore.Mvc;

namespace WeatherWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
