using Menus.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Menus.Domain.Menu.Models;
public class MenuItem : BaseEntity<int>
{
    public int Id { get; set; }
    public string Title { get; set; } // e.g., "صفحه اصلی"
    public string Slug { get; set; } // e.g., "home"
    public string Url { get; set; } // e.g., "/home"
    public int? ParentId { get; set; } // For submenus
    public MenuItem? Parent { get; set; }

    public class MenuConfiguration : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Title).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Slug).IsRequired().HasMaxLength(500);
            builder.Property(p => p.Url).IsRequired().HasMaxLength(200);
            builder.Property(p => p.ParentId).IsRequired().HasMaxLength(500);
        }


    }
}
