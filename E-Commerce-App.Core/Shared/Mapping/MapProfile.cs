using AutoMapper;
using E_Commerce_App.Core.Shared.DTOs;
using E_Commerce_App.Core.Entities;

namespace E_Commerce_App.Core.Shared.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            // Map Category with DTOS
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
        }
    }
}
