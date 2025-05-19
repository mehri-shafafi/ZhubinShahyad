using Menus.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Menus.Domain.Menu.Models;
public class MenuItem : BaseEntity
{
    public string Title_FA { get; set; }
    public string Title_EN { get; set; }
    public string Title_AR { get; set; }
    public string Slug { get; set; } // e.g., "home"
    public string Url { get; set; } // e.g., "/home"
    public bool Active { get; set; }
    public string IconUrl { get; set; }

    public class MenuConfiguration : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Title_AR).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Title_EN).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Title_FA).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Slug).IsRequired().HasMaxLength(500);
            builder.Property(p => p.Url).IsRequired().HasMaxLength(200);
        }


    }
}
