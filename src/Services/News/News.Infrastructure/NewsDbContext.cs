using Microsoft.EntityFrameworkCore;
using News.Domain.Base;
using News.Domain.News.Entity;
using System.Reflection;


namespace News.Infrastructure;

public class NewsDbContext : DbContext
{
    public NewsDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Category> Categories { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("News");
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
