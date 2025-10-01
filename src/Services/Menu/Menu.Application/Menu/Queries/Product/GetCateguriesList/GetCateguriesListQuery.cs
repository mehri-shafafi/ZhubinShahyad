using MediatR;
using Menus.Application.Dtos.Menu;

namespace Menus.Application.Menus.Queries.Menu.GetCateguriesList
{
    public class GetCateguriesListQuery : MenuCategoryDto, IRequest<List<MenuCategoryDto>>
    {

    }
}
