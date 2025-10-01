using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Domain.Base;

namespace Products.Domain.Products.Models
{
    public class ProductBrandModel : BaseEntity<int>
    {
        public string Name { get; set; }
        public string LogoURL { get; set; }
        public string Description { get; set; }
        public ICollection<ProductModel> Products { get; set; } // Navigation property

     
    }
}
