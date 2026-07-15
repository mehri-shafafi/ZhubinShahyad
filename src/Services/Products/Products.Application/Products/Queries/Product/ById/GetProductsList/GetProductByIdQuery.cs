using MediatR;
using Products.Application.Dtos.Products;
using Products.Domain.Products.Entity;

namespace Products.Application.Products.Queries.Product.ById.GetProductsList;

public class GetProductByIdQuery : IRequest<ProductResponseDto<ProductDto>>
{
    public int ProductId { get; set; }
}
