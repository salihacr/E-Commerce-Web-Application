using AutoMapper;
using E_Commerce_App.Core.Entities;
using E_Commerce_App.Core.Services;
using E_Commerce_App.WebUI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_App.WebUI.Controllers
{
    //[Route("Admin/Product")]
    public class AdminProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IService<Color> _colorService;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public AdminProductController(
            IService<Color> colorService,
            IProductService productService,
            ICategoryService categoryService,
            IMapper mapper)
        {
            _colorService = colorService;
            _productService = productService;
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();
            return View(products);
        }
        //[Route("Add")]
        //[Route("Edit/{id}")]
        [HttpGet]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            ViewData["ProductId"] = id.ToString();
            var categories = await _categoryService.GetAllAsync();
            var colors = await _colorService.GetAllAsync();
            try
            {
                if (id == 0)
                {
                    return View(new ProductViewModel()
                    {
                        Product = new Product() { MainImage = "" },
                        Categories = categories,
                        Images = null,
                        Colors = colors
                    });
                }
                else
                {
                    var product = await _productService.GetByIdAsync(id);
                    var productViewModel = new ProductViewModel()
                    {
                        Product = product,
                        Categories = categories,
                        Colors = colors,
                        Images = product.Images
                    };
                    return View(productViewModel);
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex);
                throw;
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([FromForm] Product product, IFormFile mainImage, List<IFormFile> allImages, int[] categoryIds, int[] colorIds)
        {
            if (ModelState.IsValid)
            {
                if (product.Id == 0)
                    await _productService.AddAsync(product);
                else
                    _productService.Update(product);

                return Json(new { isValid = true, html = Helpers.UIHelper.RenderRazorViewToString(this, "_AllCategories", await _productService.GetAllAsync()) });
            }
            return Json(new { isValid = false, html = Helpers.UIHelper.RenderRazorViewToString(this, "AddOrEdit", product) });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _productService.GetByIdAsync(id);
            _productService.Remove(category);
            return Json(new { isValid = true, html = Helpers.UIHelper.RenderRazorViewToString(this, "_AllCategories", await _productService.GetAllAsync()) });
        }
    }
}
