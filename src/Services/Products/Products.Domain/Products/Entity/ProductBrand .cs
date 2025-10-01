using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Domain.Base;

namespace Products.Domain.Products.Entity
{
    public class ProductBrand : BaseEntity<int>
    {
        public string Name { get; set; }
        public string LogoURL { get; set; }
        public string Description { get; set; }
        public ICollection<ProductEntity> Products { get; set; } // Navigation property

        public class ProductBrandConfiguration : IEntityTypeConfiguration<ProductBrand>
        {
            public void Configure(EntityTypeBuilder<ProductBrand> builder)
            {
                builder.ToTable("ProductBrands");
                builder.HasKey(x => x.Id);
                builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
                builder.Property(p => p.LogoURL).IsRequired().HasMaxLength(200);
                builder.Property(p => p.Description).IsRequired().HasMaxLength(500);
            }
        }
    }
}
