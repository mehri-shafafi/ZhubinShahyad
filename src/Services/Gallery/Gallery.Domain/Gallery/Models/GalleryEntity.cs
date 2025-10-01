using Gallery.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gallery.Domain.Gallery.Models;
public class GalleryEntity : BaseEntity<int>
{

    public string ImageUrl { get; set; }
    public int CategoriesGalleryId { get; set; }
    public CategoriesGallery Category { get; set; } // این باید وجود داشته باشه

    public class GalleryConfiguration : IEntityTypeConfiguration<GalleryEntity>
    {
        public void Configure(EntityTypeBuilder<GalleryEntity> builder)
        {
            builder.Property(p => p.ImageUrl).HasMaxLength(2000).IsRequired();
           
        }


    }
}
