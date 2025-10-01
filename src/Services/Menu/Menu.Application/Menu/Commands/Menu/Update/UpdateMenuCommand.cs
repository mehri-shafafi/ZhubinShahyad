using MediatR;
using Menus.Application.Dtos.Menu;

namespace Menus.Application.Menus.Commands.Menu.UpdateMenu;

public class UpdateMenuCommand : MenuResDto, IRequest<bool>
{

}