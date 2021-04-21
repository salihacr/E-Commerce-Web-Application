using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_App.WebUI.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("Admin/Order")]
    public class AdminOrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
