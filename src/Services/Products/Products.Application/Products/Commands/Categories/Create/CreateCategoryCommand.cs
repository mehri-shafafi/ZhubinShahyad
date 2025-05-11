using MediatR;
using Products.Domain.Dtos.Products;

namespace Products.Application.Products.Commands.Categories.Create;


public class CreateCategoryCommand : ProductCategoryDto, IRequest<ProductCategoryDto>
{
}