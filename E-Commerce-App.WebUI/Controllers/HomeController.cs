using E_Commerce_App.Core.Entities;
using E_Commerce_App.Core.Services;
using E_Commerce_App.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
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
        [Route("products/page={page}")]
        public async Task<IActionResult> Index(string page)
        {
            Convert.ToInt32(page);
            const int pageSize = 3;
            var productListViewModel = new ProductListViewModel()
            {
                PageInfo = new PageInfo
                {
                    TotalItem = _productService.GetProductCount(),
                    CurrentPage = Convert.ToInt32(page),
                    ItemsPerPage = pageSize,
                },
                Products = await _productService.GetHomePageProducts(Convert.ToInt32(page), pageSize)
            };
            return View(productListViewModel);
        }
        [Route("/GetProducts/{page}")]
        [HttpGet]
        public async Task<IActionResult> GetProducts(string page)
        {
            Convert.ToInt32(page);
            const int pageSize = 3;
            var productListViewModel = new ProductListViewModel()
            {
                PageInfo = new PageInfo
                {
                    TotalItem = _productService.GetProductCount(),
                    CurrentPage = Convert.ToInt32(page),
                    ItemsPerPage = pageSize,
                },
                Products = await _productService.GetHomePageProducts(Convert.ToInt32(page), pageSize)
            };
            return Json(new { data = productListViewModel });
        }
    }
}
