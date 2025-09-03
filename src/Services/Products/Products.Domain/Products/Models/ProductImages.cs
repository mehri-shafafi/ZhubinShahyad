using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.Products.Models
{
    public class ProductImages : BaseEntity
    {
        public int ProductId { get; set; }
        public string ImageUrl { get; set; } = default!;
        public int SortOrder { get; set; }
        // Navigation Property
        // Navigation Property
        public ICollection<ProductEntity> Products { get; set; }
        public class ProductImagesConfiguration : IEntityTypeConfiguration<ProductImages>
        {
            public void Configure(EntityTypeBuilder<ProductImages> builder)
            {
                //builder.HasKey(x => x.Id);
                builder.Property(p => p.ProductId).IsRequired();
                builder.Property(p => p.ImageUrl).HasMaxLength(2000);
                builder.Property(p => p.SortOrder).IsRequired();

            }
        }
    }
}
