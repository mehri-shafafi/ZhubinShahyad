using Menus.Domain.Base;
using Menus.Domain.Menu.Models;
using Microsoft.EntityFrameworkCore;


namespace Menus.Infrastructure;

public class MenuDbContext : DbContext
{
    public MenuDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<MenuCategory> MenuCategories { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MenuItem.MenuConfiguration());
        modelBuilder.ApplyConfiguration(new MenuCategory.MenuCategoryConfiguration());
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<BaseEntity<Guid>>()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
                entry.Entity.CreationDateTime = DateTime.UtcNow;

            entry.Entity.ModificationDateTime = DateTime.UtcNow;
        }

        return base.SaveChangesAsync(cancellationToken);
    }

}
