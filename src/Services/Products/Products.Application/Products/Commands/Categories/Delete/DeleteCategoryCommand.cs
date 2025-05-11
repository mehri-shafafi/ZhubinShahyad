using MediatR;

namespace Products.Application.Products.Commands.Categories.Delete;

public class DeleteCategoryCommand : IRequest<bool>
{
    public int Id { get; set; }
}