using AutoMapper;
using E_Commerce_App.Core.Entities;
using E_Commerce_App.Core.Services;
using E_Commerce_App.Core.Shared;
using E_Commerce_App.Core.Shared.DTOs;
using E_Commerce_App.WebUI.Helpers;
using E_Commerce_App.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce_App.WebUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IService<ProductColor> _productColorService;
        private readonly IService<ProductCategory> _productCategoryService;
        private readonly IService<Image> _imageService;
        private readonly IService<Color> _colorService;
        private readonly IService<CartItem> _cartItemService;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ProductCRUDHelper _crudHelper;
        public AdminProductController(
            IService<Color> colorService,
            IService<ProductColor> productColorService,
            IService<ProductCategory> productCategoryService,
            IService<Image> imageService,
            IProductService productService,
            ICategoryService categoryService,
            IMapper mapper, IService<CartItem> cartItemService)
        {
            _colorService = colorService;
            _productColorService = productColorService;
            _productCategoryService = productCategoryService;
            _imageService = imageService;
            _productService = productService;
            _categoryService = categoryService;
            _mapper = mapper;
            _crudHelper = new ProductCRUDHelper(productColorService, productCategoryService, imageService, mapper);
            _cartItemService = cartItemService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await GetProducts());
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
                        ProductDto = new ProductDto() { MainImage = "" },
                        Categories = _mapper.Map<IEnumerable<CategoryDto>>(categories),
                        Images = null,
                        Colors = _mapper.Map<IEnumerable<ColorDto>>(colors)
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
                        ProductDto = _mapper.Map<ProductDto>(product),
                        Categories = _mapper.Map<IEnumerable<CategoryDto>>(categories),
                        SelectedCategories = _mapper.Map<IEnumerable<ProductCategoryDto>>(selectedCategories),
                        Colors = _mapper.Map<IEnumerable<ColorDto>>(colors),
                        SelectedColors = _mapper.Map<IEnumerable<ColorDto>>(selectedColors),
                        Images = _mapper.Map<IEnumerable<ImageDto>>(productImages)
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
        public async Task<IActionResult> AddOrEdit([FromForm] ProductDto productDto, IFormFile mainImage, List<IFormFile> allImages, int[] categoryIds, int[] colorIds)
        {

            // TODO url tekrarlama durumunu kontrol et ona göre hata gönder
            try
            {
                if (ModelState.IsValid)
                {
                    if (string.IsNullOrEmpty(productDto.Id))
                    {
                        var newProduct = await _crudHelper.ProductForAdd(productDto, mainImage, allImages, categoryIds, colorIds);
                        await _productService.AddAsync(_mapper.Map<ProductDto, Product>(newProduct));
                    }
                    else
                    {
                        var editedProduct = await _crudHelper.ProductForEdit(productDto, mainImage, allImages, categoryIds, colorIds);
                        _productService.Update(_mapper.Map<ProductDto, Product>(editedProduct));
                    }
                    return Json(new { isValid = true, message = Messages.JSON_CREATE_MESSAGE("Ürün") });
                }
                return Json(new { isValid = false, message = "Lütfen tüm alanları doldurunuz." });
            }
            catch (Exception)
            {
                return Json(new { isValid = false, message = Messages.JSON_CREATE_MESSAGE("Ürün", false) });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            try
            {
                var product = await _productService.SingleOrDefaultAsync(p => p.Id == id);

                // ürün silineceği için sepetlerde bulunan bu ürünü kaldırıyoruz.
                var cartItems = await _cartItemService.Where(p => p.ProductId == product.Id);
                _cartItemService.RemoveRange(cartItems);

                product.IsActive = false;
                _productService.RemoveProduct(product); // carttan sil ürünleri bu islemden sonra
                

                //_productService.Remove(product);
                //var productColors = await _productColorService.Where(p => p.ProductId == product.Id);
                //var productCategories = await _productCategoryService.Where(p => p.ProductId == product.Id);
                //_productColorService.RemoveRange(productColors);
                //_productCategoryService.RemoveRange(productCategories);
                return Json(new { isValid = true, message = Messages.JSON_REMOVE_MESSAGE("Ürün"), html = Helpers.UIHelper.RenderRazorViewToString(this, "_AllProducts", await GetProducts()) });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        /*
         Get All Products (but public columns :D)
         */
        public async Task<IEnumerable<ProductDto>> GetProducts()
            => _mapper.Map<IEnumerable<ProductDto>>(await _productService.Where(p=>p.IsActive));
    }
}
