using AutoMapper;
using E_Commerce_App.Core.Entities;
using E_Commerce_App.Core.Services;
using E_Commerce_App.WebUI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
        private readonly IService<Image> _imageService;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public AdminProductController(
            IService<Color> colorService,
            IService<Image> imageService,
            IProductService productService,
            ICategoryService categoryService,
            IMapper mapper)
        {
            _colorService = colorService;
            _imageService = imageService;
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
        public async Task<IActionResult> AddOrEdit(string id = "")
        {
            ViewData["ProductId"] = id.ToString();
            var categories = await _categoryService.GetAllAsync();
            var colors = await _colorService.GetAllAsync();
            try
            {
                if (id == "")
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
                    //var product = await _productService.SingleOrDefaultAsync(p => p.Id == id);
                    var product = await _productService.GetProductWithCategoriesById(id);
                    var selectedCategories = product.ProductCategories;
                    var selectedColors = product.Colors;
                    var productImages = await _imageService.Where(i => i.ProductId == product.Id);
                    var productViewModel = new ProductViewModel()
                    {
                        Product = product,
                        Categories = categories,
                        SelectedCategories = selectedCategories,
                        Colors = colors,
                        SelectedColors = selectedColors,
                        Images = productImages
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
            // TODO url tekrarlama durumunu kontrol et ona göre hata gönder
            var id = product.Id;
            var newProduct = await GetProduct(product, mainImage, allImages, categoryIds, colorIds);
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(id))
                    await _productService.AddAsync(newProduct);
                else
                    _productService.Update(newProduct);

                return Json(new { isValid = true, message = "Ürün kaydı başarılı." });
            }
            return Json(new { isValid = false, message = "Ürün kayıt hatası." });
        }
        public async Task<Product> GetProduct(Product product, IFormFile mainImage, List<IFormFile> allImages, int[] categoryIds, int[] colorIds)
        {
            if (string.IsNullOrEmpty(product.Id))
            {
                product.Id = Guid.NewGuid().ToString();
                product.CreationDate = DateTime.Now;
                // Url
                product.Url += "-" + DateTime.Now.ToString("HHmmFFFFF");
            }
            else
                product.DateOfUpdate = DateTime.Now;

            var before = await _imageService.Where(i => i.ProductId == product.Id);

            var productImages = new List<Image>();
            if (mainImage != null)
                product.MainImage = await Helpers.ImageHelper.SaveImage(mainImage);

            if (allImages.Count > 0) // count 0 dan büyükse
            {
                // remove before images
                if (before != null)
                {
                    foreach (var image in before)
                    {
                        var beforeImage = await _imageService.GetByIdAsync(image.Id);
                        _imageService.Remove(beforeImage);
                    }
                }
                // add new images
                foreach (var image in allImages)
                {
                    string path = await Helpers.ImageHelper.SaveImage(image);
                    var productImage = new Image() { ImagePath = path, ProductId = product.Id };
                    productImages.Add(productImage);
                }
                product.Images = productImages;
                // save images to database
                await _imageService.AddRangeAsync(productImages);
            }
            if (categoryIds.Length > 0)
            {
                var productCategories = new List<ProductCategory>();

                for (int i = 0; i < categoryIds.Length; i++)
                {
                    var productCategory = new ProductCategory() { ProductId = product.Id, CategoryId = categoryIds[i] };
                    productCategories.Add(productCategory);
                }
                product.ProductCategories = productCategories;
            }
            if (colorIds.Length > 0)
            {
                var productColors = new List<Color>();

                for (int i = 0; i < colorIds.Length; i++)
                {
                    var productColor = await _colorService.GetByIdAsync(colorIds[i]);
                    productColors.Add(productColor);
                }
                product.Colors = productColors;
            }
            return product;
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
