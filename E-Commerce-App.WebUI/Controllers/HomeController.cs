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
        public async Task<IActionResult> Index(string query)
        {
            string page = "1";
            Convert.ToInt32(page);
            const int pageSize = 4;
            if (string.IsNullOrEmpty(query))
            {
                var productListViewModel1 = new ProductListViewModel()
                {
                    PageInfo = new PageInfo
                    {
                        TotalItem = _productService.GetProductCount(),
                        CurrentPage = Convert.ToInt32(page),
                        ItemsPerPage = pageSize,
                    },
                    Products = await _productService.GetHomePageProducts(Convert.ToInt32(page), pageSize)
                };
                ViewData["query"] = "";
                return View(productListViewModel1);
            }
            var productListViewModel2 = new ProductListViewModel()
            {
                PageInfo = new PageInfo
                {
                    TotalItem = _productService.GetProductCountBySearch(query),
                    CurrentPage = Convert.ToInt32(page),
                    ItemsPerPage = pageSize,
                },
                Products = await _productService.GetSearchResult(query, Convert.ToInt32(page), pageSize)
            };
            ViewData["query"] = query;
            return View(productListViewModel2);

        }
        [Route("/GetProducts/{page}")]
        [HttpGet]
        public async Task<IActionResult> GetProducts(string page)
        {
            Convert.ToInt32(page);
            const int pageSize = 4;
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
        [Route("/GetSearchedProducts/{query}/{page}")]
        [HttpGet]
        public async Task<IActionResult> GetSearchResults(string query, string page)
        {
            // string page = "1";
            Convert.ToInt32(page);
            const int pageSize = 4;
            var productListViewModel = new ProductListViewModel()
            {
                PageInfo = new PageInfo
                {
                    TotalItem = _productService.GetProductCountBySearch(query),
                    CurrentPage = Convert.ToInt32(page),
                    ItemsPerPage = pageSize,
                },
                Products = await _productService.GetSearchResult(query, Convert.ToInt32(page), pageSize)
            };
            return Json(new { data = productListViewModel });
        }
    }
}
