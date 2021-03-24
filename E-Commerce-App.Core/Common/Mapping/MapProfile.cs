using AutoMapper;
using E_Commerce_App.Core.Common.DTOs;
using E_Commerce_App.Core.Entities;

namespace E_Commerce_App.Core.Common.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            // Map Category with DTOS
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryWithProductDto>().ReverseMap();

            // Map Product with DTOS
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
