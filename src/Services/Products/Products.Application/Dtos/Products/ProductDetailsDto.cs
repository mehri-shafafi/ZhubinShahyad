namespace Products.Application.Dtos.Products;

//برای نمایش جزئیات محصول

public class ProductDetailsDto
{
    public int ProductId { get; set; }

    public string? Name_FA { get; set; }
    public string? Name_EN { get; set; }
    public string? Name_AR { get; set; }

    public string? Description_FA { get; set; }
    public string? Description_EN { get; set; }
    public string? Description_AR { get; set; }

    public decimal Price { get; set; }

    public int CategoryId { get; set; }
    public int BrandId { get; set; }


    public string? Warranty { get; set; }

    public int Rating { get; set; }

    public List<string> ImageUrls { get; set; } = [];

    public string? CatalogUrl { get; set; }
}

