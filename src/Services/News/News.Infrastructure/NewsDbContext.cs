using Microsoft.EntityFrameworkCore;
using News.Domain.News.Models;


namespace News.Infrastructure;

public class NewsDbContext : DbContext
{
    public NewsDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<News_Article> news_Articles { get; set; }
    public DbSet<News_Author> news_Authors { get; set; }
    public DbSet<News_Category> news_Categories { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new News_Article.NewsArticleNewsConfiguration());
        modelBuilder.ApplyConfiguration(new News_Author.AuthorConfiguration());
        modelBuilder.ApplyConfiguration(new News_Category.CategoryNewsConfiguration());
    }
}
