using AutoMapper;
using E_Commerce_App.Core.Entities;
using E_Commerce_App.Core.Services;
using E_Commerce_App.WebUI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce_App.WebUI.Controllers
{
    public class AdminProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IService<Color> _colorService;
        private readonly IService<ProductColor> _productColorService;
        private readonly IService<ProductCategory> _productCategoryService;
        private readonly IService<Image> _imageService;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public AdminProductController(
            IService<Color> colorService,
            IService<ProductColor> productColorService,
            IService<ProductCategory> productCategoryService,
            IService<Image> imageService,
            IProductService productService,
            ICategoryService categoryService,
            IMapper mapper)
        {
            _colorService = colorService;
            _productColorService = productColorService;
            _productCategoryService = productCategoryService;
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
                    var product = await _productService.GetProductWithAllColumns(p => p.Id == id);
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
            var beforeCategories = await _productCategoryService.Where(i => i.ProductId == product.Id);
            if (categoryIds.Length > 0)
            {
                if (beforeCategories != null)
                {
                    foreach (var pCategory in beforeCategories)
                    {
                        _productCategoryService.Remove(pCategory);
                    }
                }
                var productCategories = new List<ProductCategory>();

                for (int i = 0; i < categoryIds.Length; i++)
                {
                    var productCategory = new ProductCategory() { ProductId = product.Id, CategoryId = categoryIds[i] };
                    productCategories.Add(productCategory);
                }
                product.ProductCategories = productCategories;
                await _productCategoryService.AddRangeAsync(productCategories);
            }
            var beforeColors = await _productColorService.Where(i => i.ProductId == product.Id);
            if (colorIds.Length > 0)
            {
                if (beforeColors != null)
                {
                    foreach (var pColor in beforeColors)
                    {
                        _productColorService.Remove(pColor);
                    }
                }
                var productColors = new List<ProductColor>();

                for (int i = 0; i < colorIds.Length; i++)
                {
                    var productColor = new ProductColor() { ProductId = product.Id, ColorId = colorIds[i] };
                    productColors.Add(productColor);
                }
                product.ProductColors = productColors;
                await _productColorService.AddRangeAsync(productColors);
            }
            return product;
        }
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            try
            {
                var product = await _productService.SingleOrDefaultAsync(p => p.Id == id);
                _productService.Remove(product);
                var productColors = await _productColorService.Where(p => p.ProductId == product.Id);
                var productCategories = await _productCategoryService.Where(p => p.ProductId == product.Id);
                _productColorService.RemoveRange(productColors);
                _productCategoryService.RemoveRange(productCategories);
                return Json(new { isValid = true, html = Helpers.UIHelper.RenderRazorViewToString(this, "_AllProducts", await _productService.GetAllAsync()) });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
