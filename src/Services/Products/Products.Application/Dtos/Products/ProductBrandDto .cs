using Products.Domain.Base;

namespace Products.Application.Dtos.Products;
public class ProductBrandDto:BaseEntity<int>
{
   public string Name { get; set; }
   public string LogoURL { get; set; }
    public string Description { get; set; }
}
