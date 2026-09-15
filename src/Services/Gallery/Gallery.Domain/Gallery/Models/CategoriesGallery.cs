using Gallery.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gallery.Domain.Gallery.Models;

public class CategoriesGallery : BaseEntity<int>
{
    public string Title_FA { get; set; }
    public string Title_EN { get; set; }
    public string Title_AR { get; set; }

    public string Desc_FA { get; set; }
    public string Desc_EN { get; set; }
    public string Desc_AR { get; set; }

    public ICollection<GalleryEntity> GalleryEntities { get; set; } = new List<GalleryEntity>();
    public class CategoriesGalleryConfiguration : IEntityTypeConfiguration<CategoriesGallery>
    {
        public void Configure(EntityTypeBuilder<CategoriesGallery> builder)
        {
            builder.ToTable("CategoriesGallery");

            builder.Property(p => p.Title_AR).HasMaxLength(500);
            builder.Property(p => p.Title_FA).HasMaxLength(500);
            builder.Property(p => p.Title_EN).HasMaxLength(500);

            builder.Property(p => p.Desc_AR).HasMaxLength(2000);
            builder.Property(p => p.Desc_FA).HasMaxLength(2000);
            builder.Property(p => p.Desc_EN).HasMaxLength(2000);


        }


    }
}
