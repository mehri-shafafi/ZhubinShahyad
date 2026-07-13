namespace Products.Application.Dtos.Products;

public class ProductManagementDto
{
    public Guid Id { get; set; }

    public string? Name_FA { get; set; }
    public string? Name_EN { get; set; }
    public string? Name_AR { get; set; }

    public string? Description_FA { get; set; }
    public string? Description_EN { get; set; }
    public string? Description_AR { get; set; }

    public decimal Price { get; set; }

    public decimal CostPrice { get; set; }

    public int BrandId { get; set; }
    public string? BrandName { get; set; }

    public int CategoryId { get; set; }

    public int StockQuantity { get; set; }

    public string? SKU { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Warranty { get; set; }

    public int Rating { get; set; }

    public string? CatalogUrl { get; set; }

    public List<string> ImageUrls { get; set; } = [];
}
