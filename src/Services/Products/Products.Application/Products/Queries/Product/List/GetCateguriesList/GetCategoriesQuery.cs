using MediatR;
using Products.Application.Dtos.Categories;

namespace Products.Application.Products.Queries.Product.List.GetCateguriesList;

public class GetCategoriesQuery : CategoryDto, IRequest<List<CategoryDto>>
{

}
