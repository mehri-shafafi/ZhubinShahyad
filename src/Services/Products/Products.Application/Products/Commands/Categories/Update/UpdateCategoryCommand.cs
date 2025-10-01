using MediatR;
using Products.Application.Dtos.Products;

namespace Products.Application.Products.Commands.Categories.Update;

public class UpdateCategoryCommand : ProductCategoryDto, IRequest<bool>
{

}