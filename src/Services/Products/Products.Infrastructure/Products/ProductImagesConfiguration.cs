using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Domain.Products.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Infrastructure.Products;

public class ProductImagesConfiguration : IEntityTypeConfiguration<ProductImages>
{
    public void Configure(EntityTypeBuilder<ProductImages> builder)
    {
        builder.ToTable("ProductImages");

        builder.HasKey(x => x.Id);
        builder.Property(p => p.ProductId).IsRequired();
        builder.Property(p => p.ImageUrl).HasMaxLength(2000);
        builder.Property(p => p.SortOrder).IsRequired();


    }
}
