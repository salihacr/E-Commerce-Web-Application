using AutoMapper;
using E_Commerce_App.Core.Entities;
using E_Commerce_App.Core.Services;
using E_Commerce_App.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Commerce_App.WebUI.Controllers
{
    [Route("Admin/Product")]
    public class AdminProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        public AdminProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();
            return View(products);
        }
        [Route("Add")]
        [Route("Edit/{id}")]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            ViewData["ProductId"] = id.ToString();
            var product = await _productService.GetByIdAsync(id);
            if (id == 0 && product == null)
                return View(new ProductViewModel());
            else
                return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([FromForm] Product product)
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
