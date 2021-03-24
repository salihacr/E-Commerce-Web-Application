using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_App.WebUI.Controllers
{
    [Route("Admin/Product")]
    public class AdminProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("Add")]
        [Route("Edit/{id}")]
        public IActionResult AddOrEdit(int id = 0)
        {
            ViewData["ProductId"] = id.ToString();
            return View();
        }
    }
}
