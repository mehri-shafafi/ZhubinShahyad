using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Education.Infrastructure
{
    public class EducationDbContextFactory : IDesignTimeDbContextFactory<EducationDbContext>
    {
        public EducationDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // مهم برای EF CLI
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<EducationDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);

            return new EducationDbContext(optionsBuilder.Options);
        }
    }
}
