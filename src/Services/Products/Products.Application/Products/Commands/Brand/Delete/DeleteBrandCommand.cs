using MediatR;

namespace Products.Application.Products.Commands.Categories.Delete;

public class DeleteBrandCommand : IRequest<bool>
{
    public int Id { get; set; }
}