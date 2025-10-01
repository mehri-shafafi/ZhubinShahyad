using MediatR;
using Menus.Application.Dtos.Menu;

namespace Menus.Application.Menu.Commands.Categories.Create;


public class CreateCategoryCommand : MenuCategoryDto, IRequest<MenuCategoryDto>
{
}