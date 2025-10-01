using MediatR;
using Menus.Application.Dtos.Menu;

namespace Menus.Application.Menus.Queries.Menu.GetMenusList
{
    public class GetMenusListQuery : MenuResDto, IRequest<List<MenuResDto>>
    {

    }
}
