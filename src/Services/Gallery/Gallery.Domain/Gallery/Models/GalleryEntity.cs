using Gallery.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace Gallery.Domain.Gallery.Models;
public class GalleryEntity : BaseEntity<int>
{
     
    public string ImageUrl { get; set; }      
    public int CategoriesGalleryId { get; set; }
    public CategoriesGallery Category { get; set; }
    public class GalleryConfiguration : IEntityTypeConfiguration<GalleryEntity>
    {
        public void Configure(EntityTypeBuilder<GalleryEntity> builder)
        {
            builder.Property(p => p.ImageUrl).HasMaxLength(2000).IsRequired();
            builder.HasOne(p => p.Category)
                .WithMany(c => c.GalleryEntities)
                .HasForeignKey(p => p.CategoriesGalleryId)
                .OnDelete(DeleteBehavior.Cascade);
        }

       
    }
}
