using Menus.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Menus.Domain.Menu.Models
{
    public class MenuCategory : BaseEntity
    {
        public string Title_FA { get; set; }
        public string Title_EN { get; set; }
        public string Title_AR { get; set; }
        public string Slug { get; set; } // e.g., "home"
        public string Url { get; set; } // e.g., "/home"
        public bool Active { get; set; }
        public string IconUrl { get; set; }
        public int DisplayOrder { get; set; }


        public ICollection<MenuItem> Products { get; set; }

        public class MenuCategoryConfiguration : IEntityTypeConfiguration<MenuCategory>
        {
            public void Configure(EntityTypeBuilder<MenuCategory> builder)
            {
                builder.HasKey(b => b.Id);
                builder.Property(p => p.Title_FA).IsRequired().HasMaxLength(200);
                builder.Property(p => p.Title_EN).IsRequired().HasMaxLength(200);
                builder.Property(p => p.Title_AR).IsRequired().HasMaxLength(200);
                builder.Property(p => p.IconUrl).IsRequired().HasMaxLength(50)
                    .HasDefaultValue("https://via.placeholder.com/85.png");
                builder.Property(p => p.CreationDateTime).IsRequired().HasDefaultValueSql("GETUTCDATE()");
                builder.Property(p => p.ModificationDateTime).IsRequired().HasDefaultValueSql("GETUTCDATE()");
                builder.Property(p => p.DisplayOrder)
                  .IsRequired()
                  .HasDefaultValue(0);

            }


        }
    }
}
