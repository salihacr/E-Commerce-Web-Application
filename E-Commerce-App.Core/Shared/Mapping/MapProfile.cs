using AutoMapper;
using E_Commerce_App.Core.Shared.DTOs;
using E_Commerce_App.Core.Entities;

namespace E_Commerce_App.Core.Shared.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            // Map Category
            CreateMap<Category, CategoryDto>().ReverseMap();
            //CreateMap<CategoryDto, Category>();
            // Map Product 
            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<Color, ColorDto>().ReverseMap();

            CreateMap<Image, ImageDto>().ReverseMap();

            CreateMap<ProductColor, ProductColorDto>().ReverseMap();

            CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();


            CreateMap<Campaign, CampaignDto>().ReverseMap();

            CreateMap<Order, OrderDto>().ReverseMap();
        }
    }
}
