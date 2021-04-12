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
        public async Task<IActionResult> List(string category, int page = 1)
        {
            const int pageSize = 3;
            var productListViewModel = new ProductListViewModel()
            {
                PageInfo = new PageInfo
                {
                    TotalItem = _productService.GetCountByCategory(category),
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    CurrentCategory = category
                },
                Products = await _productService.GetProductsByCategory(category, page, pageSize)
            };
            return View(productListViewModel);

        }
    }
}
