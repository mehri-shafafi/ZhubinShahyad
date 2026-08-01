namespace Products.Domain.Products.Models;

public class UpdateProductModel
{
    public int ProductId { get; set; }

    public string? Name_FA { get; set; }
    public string? Name_EN { get; set; }
    public string? Name_AR{ get; set; }

    public string? Description_FA { get; set; }
    public string? Description_EN { get; set; }
    public string? Description_AR { get; set; }

    public decimal? Price { get; set; }

    public int? BrandId { get; set; }
    public int? CategoryId { get; set; }

    public int? StockQuantity { get; set; }

    public string? SKU { get; set; }

    public string CatalogUrl { get; set; }

    public string? CatalogCoverImageUrl { get; set; }
    // تصاویر جدیدی که آپلود شده‌اند
    public List<string> NewImageUrls { get; set; } = new();


    // تصاویری که کاربر حذف کرده
    public List<string> DeletedImageUrls { get; set; } = new();
}