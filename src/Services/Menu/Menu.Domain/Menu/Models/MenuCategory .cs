using Menus.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Menus.Domain.Menu.Models
{
    public class MenuCategory : BaseEntity<int>
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

        public ICollection<MenuItem> Products { get; set; }

        public class MenuCategoryConfiguration : IEntityTypeConfiguration<MenuCategory>
        {
            public void Configure(EntityTypeBuilder<MenuCategory> builder)
            {
                builder.HasKey(b => b.Id);
                builder.Property(p => p.Name_EN).IsRequired().HasMaxLength(200);
                builder.Property(p => p.Name_FA).IsRequired().HasMaxLength(200);
                builder.Property(p => p.Name_AR).IsRequired().HasMaxLength(200);
                builder.Property(p => p.Description).IsRequired().HasMaxLength(5000);
                builder.Property(p => p.Permalink).IsRequired().HasMaxLength(200);
                builder.Property(p => p.BannerUrl).IsRequired().HasMaxLength(50)
                    .HasDefaultValue("https://via.placeholder.com/500x100.png");
                builder.Property(p => p.IconUrl).IsRequired().HasMaxLength(50)
                    .HasDefaultValue("https://via.placeholder.com/85.png");
                builder.Property(p => p.ThumbnailUrl).IsRequired().HasMaxLength(50).HasDefaultValue("https://via.placeholder.com/150x150.png");
                builder.Property(p => p.CreationDateTime).IsRequired().HasDefaultValueSql("GETUTCDATE()");
                builder.Property(p => p.ModificationDateTime).IsRequired().HasDefaultValueSql("GETUTCDATE()");

            }


        }
    }
}
