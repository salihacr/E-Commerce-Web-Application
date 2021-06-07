using AutoMapper;
using E_Commerce_App.Core.Entities;
using E_Commerce_App.Core.Services;
using E_Commerce_App.Core.Shared.DTOs;
using E_Commerce_App.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce_App.WebUI.Controllers
{
    public class HomeController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly IService<Image> _imageService;
        private readonly IService<Rating> _ratingService;
        public HomeController(IMapper mapper, IProductService productService, IService<Image> imageService, IService<Rating> ratingService)
        {
            _mapper = mapper;
            _productService = productService;
            _imageService = imageService;
            _ratingService = ratingService;
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
        [Route("product/{url}")]
        public async Task<IActionResult> Detail(string url)
        {
            var product = await _productService.GetProductWithAllColumns(p => p.Url == url);
            var productImages = await _imageService.Where(i => i.ProductId == product.Id);
            var productRatings = await _ratingService.Where(i => i.ProductId == product.Id);
            if (product == null)
            {
                return NotFound();
            }
            var selectedCategories = product.ProductCategories;
            var selectedColors = product.Colors;
            var productViewModel = new ProductViewModel()
            {
                ProductDto = _mapper.Map<ProductDto>(product),
                SelectedCategories = _mapper.Map<IEnumerable<ProductCategoryDto>>(selectedCategories),
                Images = _mapper.Map<IEnumerable<ImageDto>>(productImages),
                SelectedColors = _mapper.Map<IEnumerable<ColorDto>>(selectedColors),
                Ratings=_mapper.Map<List<RatingDto>>(productRatings)
            };
            return View(productViewModel);
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
