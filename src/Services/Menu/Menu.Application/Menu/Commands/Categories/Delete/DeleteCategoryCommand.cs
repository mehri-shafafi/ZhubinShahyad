using MediatR;

namespace Menus.Application.Menus.Commands.Categories.Delete;

public class DeleteCategoryCommand : IRequest<bool>
{
    public int Id { get; set; }
}