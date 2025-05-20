using Products.Domain.Base;
using Products.Domain.Products.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace Products.Domain.Products.Models;
public class ProductEntity : BaseEntity
{
    public string Name_FA { get; set; }
    public string Name_EN { get; set; }
    public string Name_AR { get; set; }
    public string? Description_FA { get; set; }
    public string? Description_EN { get; set; }
    public string? Description_AR { get; set; }
    public decimal Price { get; set; }
    public int? BrandId { get; set; }
    public int? CategoryId { get; set; }
    public string StockQuantity { get; set; }
    public string SKU { get; set; }
    public string ImageURL { get; set; }
    public string Warranty { get; set; }
    public int Rating { get; set; }

    // روابط
    public ProductBrand ProductBrand { get; set; } // رابطه با برند
    public ProductCategory Category { get; set; } // رابطه با دسته‌بندی

    public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            //builder.HasKey(x => x.Id);
            builder.Property(p => p.Name_AR).HasMaxLength(200);
            builder.Property(p => p.Description_AR).HasMaxLength(2000);
            builder.Property(p => p.Name_EN).HasMaxLength(200);
            builder.Property(p => p.Description_EN).HasMaxLength(2000);
            builder.Property(p => p.Name_FA).HasMaxLength(200);
            builder.Property(p => p.Description_FA).HasMaxLength(2000);
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.StockQuantity);
            builder.Property(p => p.SKU).HasMaxLength(100);
            builder.Property(p => p.ImageURL).HasMaxLength(300);
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
          //  builder.HasData(SeedProducts());
        }
      
        private List<ProductEntity> SeedProducts()
        {
            var categories = new List<ProductEntity>();
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string categorySeedPath = Path.Combine(baseDirectory, "SeedData", "ProductSeed.json");

            if (!File.Exists(categorySeedPath))
            {
                throw new FileNotFoundException($"Seed file not found: {categorySeedPath}");
            }

            string json = File.ReadAllText(categorySeedPath);
            categories = JsonSerializer.Deserialize<List<ProductEntity>>(json) ?? new List<ProductEntity>();

            return categories;
        }
    }
}
