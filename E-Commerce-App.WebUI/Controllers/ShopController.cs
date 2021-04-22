using AutoMapper;
using E_Commerce_App.Core.Entities;
using E_Commerce_App.Core.Services;
using E_Commerce_App.Core.Shared.DTOs;
using E_Commerce_App.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce_App.WebUI.Controllers
{

    public class ShopController : Controller
    {
        private readonly IProductService _productService;
        private readonly IService<Image> _imageService;
        private readonly IMapper _mapper;
        public ShopController(IMapper mapper, IProductService productService, IService<Image> imageService)
        {
            _mapper = mapper;
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
                ProductDto = new ProductDto() { MainImage = "" },
                Categories = _mapper.Map<IEnumerable<CategoryDto>>(selectedCategories),
                Images = _mapper.Map<IEnumerable<ImageDto>>(productImages),
                Colors = _mapper.Map<IEnumerable<ColorDto>>(selectedColors)
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
