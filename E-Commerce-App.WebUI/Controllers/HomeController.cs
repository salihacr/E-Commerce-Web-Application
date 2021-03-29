using E_Commerce_App.Core.Repositories;
using E_Commerce_App.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Commerce_App.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        public HomeController(IProductService productService)
        {
            _productService = productService;
        }
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            return View(await _productService.GetHomePageProducts());
        }
    }
}
