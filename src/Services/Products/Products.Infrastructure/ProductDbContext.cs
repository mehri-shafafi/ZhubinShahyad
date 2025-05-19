using Microsoft.EntityFrameworkCore;
using Products.Domain.Base;
using Products.Domain.Products.Models;


namespace Products.Infrastructure;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<ProductCategory> ProductCategory { get; set; }
    public DbSet<ProductBrand> Brands { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductEntity.ProductConfiguration());
        modelBuilder.ApplyConfiguration(new ProductCategory.ProductCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new ProductBrand.ProductBrandConfiguration());
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
