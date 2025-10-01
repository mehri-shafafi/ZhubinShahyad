using MediatR;
using Products.Application.Dtos.Products;

namespace Products.Application.Products.Queries.Product.GetCateguriesList
{
    public class GetCateguriesListQuery : ProductCategoryDto, IRequest<List<ProductCategoryDto>>
    {

    }
}
