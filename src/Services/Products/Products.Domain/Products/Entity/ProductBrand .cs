using Products.Domain.Base;

namespace Products.Domain.Products.Entity;

public class ProductBrand : BaseEntity<int>
{
    public string Name { get; set; }
    public string LogoURL { get; set; }
    public string Description { get; set; }
    public ICollection<ProductEntity> Products { get; set; } // Navigation property


}
