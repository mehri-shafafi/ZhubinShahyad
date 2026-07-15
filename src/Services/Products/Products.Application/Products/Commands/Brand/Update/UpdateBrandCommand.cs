using MediatR;
using Products.Application.Dtos.Brands;

namespace Products.Application.Products.Commands.Categories.Update;

public class UpdateBrandCommand : BrandDto, IRequest<bool>
{
    public int Id { get; set; }

}