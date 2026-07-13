using MediatR;
using Products.Application.Dtos.Brands;

namespace Products.Application.Products.Queries.Product.GetBrandProducts
{
    public class GetBrandProductsListQuery :  IRequest<List<ProductBrandDto>>
    {

    }
}
