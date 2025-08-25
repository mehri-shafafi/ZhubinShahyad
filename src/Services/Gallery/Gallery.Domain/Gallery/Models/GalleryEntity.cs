using Gallery.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace Gallery.Domain.Gallery.Models;
public class GalleryEntity : BaseEntity<int>
{
    public string Title_FA { get; set; }       
    public string Title_EN { get; set; }        
    public string Title_AR { get; set; }      
    public string ImageUrl { get; set; }      

    public class GalleryConfiguration : IEntityTypeConfiguration<GalleryEntity>
    {
        public void Configure(EntityTypeBuilder<GalleryEntity> builder)
        {
            //builder.HasKey(x => x.Id);
            builder.Property(p => p.Title_AR).HasMaxLength(200);
            builder.Property(p => p.Title_FA).HasMaxLength(2000);
            builder.Property(p => p.Title_EN).HasMaxLength(200);
            builder.Property(p => p.ImageUrl).HasMaxLength(2000);

         

         
        }

       
    }
}
