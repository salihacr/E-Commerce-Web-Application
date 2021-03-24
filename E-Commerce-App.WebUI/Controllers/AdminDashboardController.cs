using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_App.WebUI.Controllers
{
    public class AdminDashboardController : Controller
    {
        [Route("Admin/Dashboard")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
