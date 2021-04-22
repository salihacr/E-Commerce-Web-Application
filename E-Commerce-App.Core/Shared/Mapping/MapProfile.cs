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
        }
    }
}
