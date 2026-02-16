using MediatR;
using Products.Application.Dtos.Products;

namespace Products.Application.Products.Commands.Product.CreateMedical;


public class CreateProductCommand : ProductReqDto, IRequest<ProductResDto>
{
    public string Name_FA { get; set; }
    public string Name_EN { get; set; }
    public string Name_AR { get; set; }
    public string? Description_FA { get; set; }
    public string? Description_EN { get; set; }
    public string? Description_AR { get; set; }
    public decimal Price { get; set; }
    public int? BrandId { get; set; }
    public int? CategoryId { get; set; }
    public int StockQuantity { get; set; }
    public string SKU { get; set; }
    public string CatalogURL { get; set; }
    public string catalog_cover_image_url { get; set; }
    public string Warranty { get; set; }
    public int Rating { get; set; }
    public List<string> ImageUrls { get; set; }
    public string CatalogCoverImageUrl { get; set; }
}