using Products.Domain.Base;

namespace Products.Application.Dtos.Brands;
public class BrandDto:BaseEntity<int>
{
   public string Name { get; set; }
   public string LogoURL { get; set; }
    public string Description { get; set; }
}
