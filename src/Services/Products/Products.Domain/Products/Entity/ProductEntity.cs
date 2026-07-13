using Products.Domain.Base;

namespace Products.Domain.Products.Entity;

public class ProductEntity : BaseEntity
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
    public string CatalogURL { get; set; }
    public string catalog_cover_image_url { get; set; }
    public string Warranty { get; set; }
    public int Rating { get; set; }

    // روابط
    public ProductBrand ProductBrand { get; set; } // رابطه با برند
    public ProductCategory Category { get; set; } // رابطه با دسته‌بندی
    public ICollection<ProductImages> Images { get; set; } = new List<ProductImages>();

   
}
