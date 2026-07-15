using MediatR;
using Products.Application.Dtos.Categories;

namespace Products.Application.Products.Queries.Product.List.GetCateguriesList;

public class GetCategoryByIdQuery : CategoryDto, IRequest<CategoryDto>
{
    public int CategoryId { get; set; }
}
