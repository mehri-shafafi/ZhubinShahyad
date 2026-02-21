using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Domain.Products.Entity;

namespace Products.Infrastructure.Products;

public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(x => x.Id);
        builder.Property(p => p.Name_AR).HasMaxLength(200);
        builder.Property(p => p.Description_AR).HasMaxLength(2000);
        builder.Property(p => p.Name_EN).HasMaxLength(200);
        builder.Property(p => p.Description_EN).HasMaxLength(2000);
        builder.Property(p => p.Name_FA).HasMaxLength(200);
        builder.Property(p => p.Description_FA).HasMaxLength(2000);
        builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
        builder.Property(p => p.StockQuantity);
        builder.Property(p => p.SKU).HasMaxLength(100);
        builder.Property(p => p.CatalogURL).HasMaxLength(300);
        builder.Property(p => p.catalog_cover_image_url).HasMaxLength(300);
        builder.Property(p => p.Warranty).HasMaxLength(200);
        builder.Property(p => p.Rating).HasDefaultValue(0);

        // تنظیم رابطه با دسته‌بندی
        builder.HasOne(p => p.Category)
               .WithMany(c => c.Products)
               .HasForeignKey(p => p.CategoryId)
               .IsRequired(false);

        // تنظیم رابطه با برند
        builder.HasOne(p => p.ProductBrand)
               .WithMany(b => b.Products)
               .HasForeignKey(p => p.BrandId)
               .IsRequired(false);
        //   builder.HasData(SeedProducts());

        builder.HasMany(p => p.Images)
         .WithOne(i => i.Product)
         .HasForeignKey(i => i.ProductId)
         .OnDelete(DeleteBehavior.Cascade);


    }
}
