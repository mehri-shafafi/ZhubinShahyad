using Education.Domain.Education.Dtos;
using Education.Domain.Education.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace Education.Infrastructure;

public class EducationDbContext : DbContext
{
    public EducationDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Training> training { get; set; }
    public DbSet<TrainingTranslation> trainingTranslations { get; set; }
    public DbSet<TrainingCategory> trainingCategories { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Education");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
