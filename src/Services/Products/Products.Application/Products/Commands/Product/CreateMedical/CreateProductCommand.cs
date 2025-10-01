using MediatR;
using Products.Application.Dtos.Products;

namespace Products.Application.Products.Commands.Product.CreateMedical;


public class CreateProductCommand : ProductReqDto, IRequest<ProductResDto>
{
}