using MediatR;
using Products.Application.Dtos.Products;

namespace Products.Application.Products.Queries.Product.GetProductsList
{
    public class GetProductsListQuery : ProductFilterPageReqDto, IRequest<List<ProductDto>>
    {

    }
}
