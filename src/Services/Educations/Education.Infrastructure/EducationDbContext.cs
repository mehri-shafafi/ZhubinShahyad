using Education.Domain.Education.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace Education.Infrastructure;

public class EducationDbContext : DbContext
{
    public EducationDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Training> Training { get; set; }
    public DbSet<TrainingTranslation> TrainingTranslations { get; set; }
    public DbSet<TrainingCategory> TrainingCategories { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Education");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
