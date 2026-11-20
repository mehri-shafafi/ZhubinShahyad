using Microsoft.EntityFrameworkCore;
using Products.Domain.Base;
using Products.Domain.Products.Entity;
using Products.Infrastructure.Products;
using System.Reflection;


namespace Products.Infrastructure;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ProductBrand> Brands { get; set; }
    public DbSet<ProductImages> ProductImages { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Product");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
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
