using MediatR;

namespace Products.Application.Products.Commands.Product.DeleteProductImage;

public class DeleteProductImageCommand : IRequest<bool>
{
    public int Id { get; set; }
}