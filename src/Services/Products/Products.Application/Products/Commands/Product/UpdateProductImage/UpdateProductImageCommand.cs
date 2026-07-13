using MediatR;
using Products.Application.Dtos.Products;

namespace Products.Application.Products.Commands.Product.UpdateProductImage;

public class UpdateProductImageCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string? ImageUrl { get; set; }
    public int? SortOrder { get; set; }
      
}