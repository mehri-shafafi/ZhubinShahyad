using MediatR;
using Products.Application.Dtos.Products;
using Products.Domain.Products.Entity;

namespace Products.Application.Products.Queries.Product.List.GetProductsList;

public class GetProductsListQuery :  IRequest<ProductResponseDto<List<ProductDto>>>
{
}
