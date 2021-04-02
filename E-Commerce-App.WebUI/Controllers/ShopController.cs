using E_Commerce_App.Core.Entities;
using E_Commerce_App.Core.Services;
using E_Commerce_App.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Commerce_App.WebUI.Controllers
{

    public class ShopController : Controller
    {
        private readonly IProductService _productService;
        private readonly IService<Image> _imageService;
        public ShopController(IProductService productService, IService<Image> imageService)
        {
            _productService = productService;
            _imageService = imageService;
        }
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            return View(await _productService.GetHomePageProducts());
        }
        public async Task<IActionResult> Detail(string url)
        {
            var product = await _productService.GetProductWithAllColumns(p => p.Url == url);
            var productImages = await _imageService.Where(i => i.ProductId == product.Id);
            if (product == null)
            {
                return NotFound();
            }
            var selectedCategories = product.ProductCategories;
            var selectedColors = product.Colors;
            var productViewModel = new ProductViewModel()
            {
                Product = product,
                SelectedCategories = selectedCategories,
                SelectedColors = selectedColors,
                Images = productImages
            };
            return View(productViewModel);
        }
    }
}
