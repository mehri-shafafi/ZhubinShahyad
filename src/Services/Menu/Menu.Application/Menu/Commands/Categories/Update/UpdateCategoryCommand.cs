using MediatR;
using Menus.Domain.Dtos.Menu;

namespace Menus.Application.Menus.Commands.Categories.Update;

public class UpdateCategoryCommand : MenuCategoryDto, IRequest<bool>
{

}