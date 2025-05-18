using MediatR;
using Menus.Domain.Dtos.Menu;

namespace Menus.Application.Menu.Commands.Menu.Create;


public class CreateMenuCommand : MenuResDto, IRequest<MenuResDto>
{
}