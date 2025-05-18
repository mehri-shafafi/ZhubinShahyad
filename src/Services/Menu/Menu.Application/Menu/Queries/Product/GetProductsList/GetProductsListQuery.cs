using MediatR;
using Menus.Domain.Base;
using Menus.Domain.Dtos.Menu;

namespace Menus.Application.Menus.Queries.Menu.GetMenusList
{
    public class GetMenusListQuery : MenuResDto, IRequest<List<MenuResDto>>
    {

    }
}
