using MediatR;
using Products.Domain.Base;
using Products.Domain.Dtos.Products;

namespace Products.Application.Products.Queries.Product.GetCateguriesList
{
    public class GetCateguriesListQuery : ProductCategoryDto, IRequest<List<ProductCategoryDto>>
    {

    }
}
