using Products.Application.Products.Commands.Product.CreateMedical;

namespace Products.Application.Dtos.Products;
//برای لیست محصولات
public class ProductDto
{
    public int ProductId { get; set; }

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

    public string CatalogURL { get; set; }

    public string? CatalogCoverImageUrl { get; set; }

    public string Warranty { get; set; }
    public string FolderName { get; set; }

    public int Rating { get; set; }

    public bool IsActive { get; set; }

    public List<ProductImageDto> ImageUrls { get; set; } = [];

}
