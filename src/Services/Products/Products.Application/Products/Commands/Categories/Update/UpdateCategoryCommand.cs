using MediatR;
using Products.Application.Dtos.Categories;

namespace Products.Application.Products.Commands.Categories.Update;

public class UpdateCategoryCommand : CategoryDto, IRequest<bool>
{

}