using MediatR;
using Menus.Domain.Dtos.Menu;

namespace Menus.Application.Menus.Commands.Menu.UpdateMenu;

public class UpdateMenuCommand : MenuResDto, IRequest<bool>
{

}