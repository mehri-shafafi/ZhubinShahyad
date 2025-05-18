using AutoMapper;
using Menus.Domain.Dtos.Menu;
using Menus.Domain.Menu.Models;
namespace Menus.Infrastructure.Menus
{
    public class MenuMappingProfile : Profile
    {
        public MenuMappingProfile()
        {
            CreateMap<MenuItem, MenuResDto>().ReverseMap();
           
        }
    }
}
