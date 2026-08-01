using Products.Domain.Base;

namespace Products.Domain.Products.Models;
public class ProductModel : BaseEntity
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

    public int Rating { get; set; }
    public int SortOrder { get; set; }

    public bool IsActive { get; set; }

    public List<string> ImageUrls { get; set; } = [];

}
