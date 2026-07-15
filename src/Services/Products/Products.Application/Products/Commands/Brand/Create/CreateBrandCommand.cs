using MediatR;
using Products.Application.Dtos.Brands;

namespace Products.Application.Products.Commands.Brand.Create;


public class CreateBrandCommand : BrandDto, IRequest<BrandDto>
{
}