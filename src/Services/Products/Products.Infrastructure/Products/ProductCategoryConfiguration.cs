using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Domain.Products.Entity;

namespace Products.Infrastructure.Products
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {

        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategories");
            builder.HasKey(b => b.Id);
            builder.Property(p => p.Name_EN).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Name_FA).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Name_AR).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Description).HasMaxLength(5000);
            builder.Property(p => p.Active).IsRequired();
            builder.Property(p => p.Priority).IsRequired();
            builder.Property(p => p.Permalink).HasMaxLength(200);
            builder.Property(p => p.BannerUrl).HasMaxLength(200);
            builder.Property(p => p.IconUrl).HasMaxLength(200);
            builder.Property(p => p.ThumbnailUrl).HasMaxLength(50);
            builder.Property(p => p.CreationDateTime).IsRequired();
            builder.Property(p => p.ModificationDateTime).IsRequired();
            // builder.HasData(SeedCateguries());
        }


    }
}
