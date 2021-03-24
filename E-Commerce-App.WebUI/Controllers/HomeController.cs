using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_App.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
