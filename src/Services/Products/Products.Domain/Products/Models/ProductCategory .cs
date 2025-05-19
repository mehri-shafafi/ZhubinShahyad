using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products.Domain.Base;
using System.Text.Json;

namespace Products.Domain.Products.Models
{
    public class ProductCategory : BaseEntity
    {
        public string Name_FA { get; set; }
        public string Name_EN { get; set; }
        public string Name_AR { get; set; }
        public string Description { get; set; }
        public string Permalink { get; set; }
        public bool Active { get; set; }
        public int Priority { get; set; }
        public string BannerUrl { get; set; }
        public string IconUrl { get; set; }
        public string ThumbnailUrl { get; set; }

        public ICollection<ProductEntity> Products { get; set; }

        public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
        {
            public void Configure(EntityTypeBuilder<ProductCategory> builder)
            {
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
            private List<ProductCategory> SeedCateguries()
            {
                var categories = new List<ProductCategory>();
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string categorySeedPath = Path.Combine(baseDirectory, "SeedData", "CategorySeed.json");

                if (!File.Exists(categorySeedPath))
                {
                    throw new FileNotFoundException($"Seed file not found: {categorySeedPath}");
                }

                string json = File.ReadAllText(categorySeedPath);
                categories = JsonSerializer.Deserialize<List<ProductCategory>>(json) ?? new List<ProductCategory>();

                return categories;
            }

        }
    }
}
