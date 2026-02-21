using Products.Domain.Base;

namespace Products.Domain.Products.Entity;

public class ProductImages : BaseEntity
{

    public required string  ImageUrl { get; set; } 
    public int SortOrder { get; set; }

    public int ProductId { get; set; }
    public ProductEntity Product { get; set; }

}
