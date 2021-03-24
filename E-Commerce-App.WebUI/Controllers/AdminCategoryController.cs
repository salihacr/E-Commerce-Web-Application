using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_App.WebUI.Controllers
{
    [Route("Admin/Category")]
    public class AdminCategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
