using Contact.Domain.Contact.Models;
using Microsoft.EntityFrameworkCore;


namespace Contact.Infrastructure;

public class ContactDbContext : DbContext
{
    public ContactDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<ContactEntity> Contacts { get; set; }
    public DbSet<CategoriesContact> CategoriesContacts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ContactEntity.ContactConfiguration());
        modelBuilder.ApplyConfiguration(new CategoriesContact.CategoriesContactConfiguration());
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<ContactEntity>()
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
