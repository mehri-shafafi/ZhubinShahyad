using MediatR;
using Products.Application.Dtos.Products;

namespace Products.Application.Products.Commands.Brand.Create;


public class CreateBrandCommand : ProductBrandDto, IRequest<ProductBrandDto>
{
}