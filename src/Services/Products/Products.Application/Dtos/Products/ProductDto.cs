namespace Products.Application.Dtos.Products;
//برای لیست محصولات
public class ProductDto
{
    public int ProductId { get; set; }

    public string? Name_FA { get; set; }
    public string? Name_EN { get; set; }
    public string? Name_AR { get; set; }

    public decimal Price { get; set; }

    public string? BrandName { get; set; }

    public string? CategoryName_FA { get; set; }
    public string? CategoryName_EN { get; set; }
    public string? CategoryName_AR { get; set; }

    public string? CatalogCoverImageUrl { get; set; }

    public int StockQuantity { get; set; }
}
