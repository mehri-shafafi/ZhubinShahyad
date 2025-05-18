using MediatR;
using Menus.Domain.Base;
using Menus.Domain.Dtos.Menu;

namespace Menus.Application.Menus.Queries.Menu.GetCateguriesList
{
    public class GetCateguriesListQuery : MenuCategoryDto, IRequest<List<MenuCategoryDto>>
    {

    }
}
