using MediatR;
using Products.Application.Dtos.Categories;

namespace Products.Application.Products.Queries.Product.GetCateguriesList
{
    public class GetCategoriesQuery : ProductCategoryDto, IRequest<List<ProductCategoryDto>>
    {

    }
}
