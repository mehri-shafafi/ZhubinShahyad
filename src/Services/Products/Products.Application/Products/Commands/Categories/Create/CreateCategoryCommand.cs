using MediatR;
using Products.Application.Dtos.Categories;

namespace Products.Application.Products.Commands.Categories.Create;


public class CreateCategoryCommand : CategoryDto, IRequest<CategoryDto>
{
}