using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_App.WebUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminDashboardController : Controller
    {
        [Route("Admin/Dashboard")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
