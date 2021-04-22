using AutoMapper;
using E_Commerce_App.Core.Entities;
using E_Commerce_App.Core.Services;
using E_Commerce_App.Core.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_App.WebUI.Helpers
{
    public class ProductCRUDHelper
    {
        private readonly IService<Image> _imageService;
        private readonly IService<ProductColor> _productColorService;
        private readonly IService<ProductCategory> _productCategoryService;
        private readonly IMapper _mapper;
        public ProductCRUDHelper(
           IService<ProductColor> productColorService,
           IService<ProductCategory> productCategoryService,
           IService<Image> imageService,
           IMapper mapper)
        {
            _productColorService = productColorService;
            _productCategoryService = productCategoryService;
            _imageService = imageService;
            _mapper = mapper;
        }

        public async Task<ProductDto> ProductForAdd(ProductDto productDto, IFormFile mainImage, List<IFormFile> allImages, int[] categoryIds, int[] colorIds)
        {
            productDto.Id = Guid.NewGuid().ToString();
            productDto.CreationDate = DateTime.Now;
            productDto.Url += "-" + DateTime.Now.ToString("HHmmFFFFF");

            if (mainImage != null)
                await CreateMainImage(productDto, mainImage);

            if (allImages.Count > 0) // count 0 dan büyükse
                await CreateProductImages(productDto, allImages);

            if (categoryIds.Length > 0)
                CreateProductCategories(productDto, categoryIds);

            if (colorIds.Length > 0)
                CreateProductColors(productDto, colorIds);

            return productDto;
        }


        public async Task<ProductDto> ProductForEdit(ProductDto productDto, IFormFile mainImage, List<IFormFile> allImages, int[] categoryIds, int[] colorIds)
        {
            productDto.DateOfUpdate = DateTime.Now;

            if (mainImage != null)
                await CreateMainImage(productDto, mainImage);

            if (allImages.Count > 0) // count 0 dan büyükse
            {
                // remove before images
                await RemoveExistImages(productDto, allImages);
                // add new images
                var productImages = await CreateProductImages(productDto, allImages);
                // save images to database
                await _imageService.AddRangeAsync(_mapper.Map<IEnumerable<ImageDto>, IEnumerable<Image>>(productImages));
            }

            if (categoryIds.Length >= 0)
            {
                // Remove Existing Categories
                await RemoveExistCategories(productDto);
                // create new categories
                var productCategories = CreateProductCategories(productDto, categoryIds);
                // save new categories to database
                await _productCategoryService.AddRangeAsync(
                    _mapper.Map<IEnumerable<ProductCategoryDto>, IEnumerable<ProductCategory>>(productCategories));
            }
            if (colorIds.Length >= 0)
            {
                // remove existing productcolors
                await RemoveExistColors(productDto);
                // create new productcolors
                var productColors = CreateProductColors(productDto, colorIds);
                // save new productcolors to database
                await _productColorService.AddRangeAsync(
                    _mapper.Map<IEnumerable<ProductColorDto>, IEnumerable<ProductColor>>(productColors));
            }
            return productDto;
        }


        
        
        private static async Task CreateMainImage(ProductDto productDto, IFormFile mainImage)
        {
            productDto.MainImage = await Helpers.ImageHelper.SaveImage(mainImage);
        }
        private static async Task<List<ImageDto>> CreateProductImages(ProductDto productDto, List<IFormFile> allImages)
        {
            var productImages = new List<ImageDto>();
            // add new images
            foreach (var image in allImages)
            {
                string path = await Helpers.ImageHelper.SaveImage(image);
                var productImage = new ImageDto() { ImagePath = path, ProductId = productDto.Id };
                productImages.Add(productImage);
            }
            productDto.Images = productImages;
            return productImages;
        }
        private static List<ProductCategoryDto> CreateProductCategories(ProductDto productDto, int[] categoryIds)
        {
            var productCategories = new List<ProductCategoryDto>();
            for (int i = 0; i < categoryIds.Length; i++)
            {
                var productCategory = new ProductCategoryDto() { ProductId = productDto.Id, CategoryId = categoryIds[i] };
                productCategories.Add(productCategory);
            }
            productDto.ProductCategories = productCategories;
            return productCategories;
        }
        private static List<ProductColorDto> CreateProductColors(ProductDto productDto, int[] colorIds)
        {
            var productColors = new List<ProductColorDto>();
            for (int i = 0; i < colorIds.Length; i++)
            {
                var productColor = new ProductColorDto() { ProductId = productDto.Id, ColorId = colorIds[i] };
                productColors.Add(productColor);
            }
            productDto.ProductColors = productColors;
            return productColors;
        }

        private async Task RemoveExistImages(ProductDto productDto, List<IFormFile> allImages)
        {
            var beforeImages = await _imageService.Where(i => i.ProductId == productDto.Id);
            // remove before images
            if (beforeImages != null)
            {
                foreach (var image in beforeImages)
                {
                    var beforeImage = await _imageService.GetByIdAsync(image.Id);
                    _imageService.Remove(beforeImage);
                }
            }
        }
        private async Task RemoveExistCategories(ProductDto productDto)
        {
            var beforeCategories = await _productCategoryService.Where(i => i.ProductId == productDto.Id);
            if (beforeCategories != null)
            {
                foreach (var pCategory in beforeCategories)
                {
                    _productCategoryService.Remove(pCategory);
                }
            }
        }
        private async Task RemoveExistColors(ProductDto productDto)
        {
            var beforeColors = await _productColorService.Where(i => i.ProductId == productDto.Id);
            if (beforeColors != null)
            {
                foreach (var pColor in beforeColors)
                {
                    _productColorService.Remove(pColor);
                }
            }
        }
    }
}
