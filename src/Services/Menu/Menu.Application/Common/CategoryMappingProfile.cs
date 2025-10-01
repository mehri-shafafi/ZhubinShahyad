using AutoMapper;
using Menus.Application.Dtos.Menu;
using Menus.Domain.Menu.Models;

namespace Menus.Infrastructure.Menu
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<MenuCategory, MenuCategoryDto>().ReverseMap();
            //CreateMap<MenuCategory, MenuCategoryDto>();
        }
    }

}
