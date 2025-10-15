using MediatR;
using Products.Application.Dtos.Products;

namespace Products.Application.Products.Commands.Categories.Update;

public class UpdateBrandCommand : ProductBrandDto, IRequest<bool>
{
    public int Id { get; set; }

}