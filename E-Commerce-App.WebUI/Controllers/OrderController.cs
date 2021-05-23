using E_Commerce_App.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Commerce_App.WebUI.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        [Route("/my-orders")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Payment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Payment(OrderViewModel orderModel)
        {
            return null;
        }

    }
}
