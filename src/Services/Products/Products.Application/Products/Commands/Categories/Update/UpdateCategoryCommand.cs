using MediatR;
using Products.Domain.Dtos.Products;

namespace Products.Application.Products.Commands.Categories.Update;

public class UpdateCategoryCommand : ProductCategoryDto, IRequest<bool>
{

}