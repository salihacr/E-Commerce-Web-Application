using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_App.WebUI.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
