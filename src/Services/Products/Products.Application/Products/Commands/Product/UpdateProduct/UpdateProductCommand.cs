using MediatR;
using Products.Application.Dtos.Products;

namespace Products.Application.Products.Commands.Product.UpdateProduct;

public class UpdateProductCommand : IRequest<bool>
{
    public int ProductId { get; set; }
    public string? Name_FA { get; set; }
    public string? Name_EN { get; set; }
    public string? Name_AR { get; set; }

    public string? Description_FA { get; set; }
    public string? Description_EN { get; set; }
    public string? Description_AR { get; set; }

    public decimal? Price { get; set; }

    public int? BrandId { get; set; }
    public int? CategoryId { get; set; }

    public int? StockQuantity { get; set; }

    public string? SKU { get; set; }
    public string? Warranty { get; set; }
    public int? Rating { get; set; }
    public string? CatalogUrl { get; set; }
    public string? CatalogCoverImageUrl { get; set; }
}