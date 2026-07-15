using MediatR;
using Products.Application.Dtos.Brands;

namespace Products.Application.Products.Queries.Product.List.GetBrandProducts
{
    public class GetBrandProductsListQuery :  IRequest<List<BrandDto>>
    {

    }
}
