using MediatR;
using Products.Application.Dtos.Products;
namespace Products.Application.Products.Commands.Product.CreateMedical;


public class CreateProductCommand : IRequest<ProductResponseDto<ProductDetailsDto>>
{
    public string Name_FA { get; set; }
    public string Name_EN { get; set; }
    public string Name_AR { get; set; }

    public string? Description_FA { get; set; }
    public string? Description_EN { get; set; }
    public string? Description_AR { get; set; }

    public decimal Price { get; set; }

    public int BrandId { get; set; }
    public int CategoryId { get; set; }

    public int StockQuantity { get; set; }

    public string SKU { get; set; }
    public string? Warranty { get; set; }
    public int SortOrder { get; set; }
    public int Rating { get; set; }
    public string? CatalogUrl { get; set; }
    public List<ProductImageDto> ImageUrls { get; set; } = new();
    public string? CatalogCoverImageUrl { get; set; }
}
public class ProductImageDto
{
    public string ImageUrl { get; set; }
    public int SortOrder { get; set; }
}
