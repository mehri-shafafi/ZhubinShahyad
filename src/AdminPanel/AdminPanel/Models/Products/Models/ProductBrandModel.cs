using AdminPanel.Domain.Products.Models;
using AdminPanel.Models.Products.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Domain.Base;

namespace AdminPanel.Models.Products.Models
{
    public class ProductBrandModel : BaseEntity<int>
    {
        public string Name { get; set; }
        public string LogoURL { get; set; }
        public string Description { get; set; }
        public ICollection<ProductModel> Products { get; set; } // Navigation property

     
    }
}
