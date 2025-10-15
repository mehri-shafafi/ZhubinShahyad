using MediatR;
using Products.Application.Dtos.Products;

namespace Products.Application.Products.Queries.Product.GetBrandProducts
{
    public class GetBrandProductsListQuery :  IRequest<List<ProductBrandDto>>
    {

    }
}
