using MediatR;
using Products.Application.Dtos.Products;

namespace Products.Application.Products.Commands.Product.UpdateProduct;

public class UpdateProductCommand : ProductReqDto, IRequest<bool>
{

}