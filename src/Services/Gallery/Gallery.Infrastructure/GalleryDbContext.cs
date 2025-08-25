using Gallery.Domain.Gallery.Models;
using Microsoft.EntityFrameworkCore;


namespace Gallery.Infrastructure;

public class GalleryDbContext : DbContext
{
    public GalleryDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<GalleryEntity> Gallery { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GalleryEntity.GalleryConfiguration());
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<GalleryEntity>()
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
