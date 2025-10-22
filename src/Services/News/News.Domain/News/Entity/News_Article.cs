using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News.Domain.Base;

namespace News.Domain.News.Entity
{
    public class News_Article : BaseEntity
    {
        public string Title_FA { get; set; }
        public string Summary_FA { get; set; }
        public string Content_FA { get; set; }
        public string Title_EN { get; set; }
        public string Summary_EN { get; set; }
        public string Content_EN { get; set; }
        public string Title_AR { get; set; }
        public string Summary_AR { get; set; }
        public string Content_AR { get; set; }
        public int AuthorID { get; set; }
        public int CategoryID { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Tags { get; set; }
        public string ImageURL { get; set; }
        public long ViewsCount { get; set; }
        public News_Author news_Author { get; set; } // Navigation property
        public News_Category news_Category { get; set; } // Navigation property

        public class NewsArticleNewsConfiguration : IEntityTypeConfiguration<News_Article>
        {
            public void Configure(EntityTypeBuilder<News_Article> builder)
            {
                builder.HasKey(x => x.Id);
                builder.Property(p => p.Title_FA).IsRequired().HasMaxLength(200);
                builder.Property(p => p.Summary_FA).HasMaxLength(500);
                builder.Property(p => p.Content_FA).IsRequired();
                builder.Property(p => p.Title_EN).IsRequired().HasMaxLength(200);
                builder.Property(p => p.Summary_EN).HasMaxLength(500);
                builder.Property(p => p.Content_EN).IsRequired();
                builder.Property(p => p.Title_AR).IsRequired().HasMaxLength(200);
                builder.Property(p => p.Summary_AR).HasMaxLength(500);
                builder.Property(p => p.Content_AR).IsRequired();
                builder.Property(p => p.PublishedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                builder.Property(p => p.Tags).HasMaxLength(200);
                builder.Property(p => p.ImageURL).HasMaxLength(300);
                builder.Property(p => p.ViewsCount).HasDefaultValue(0);

                // Relationships
                builder.HasOne(p => p.news_Author)
                       .WithMany(a => a.news_Articles)
                       .HasForeignKey(p => p.AuthorID);

                builder.HasOne(p => p.news_Category)
                       .WithMany(c => c.news_Articles)
                       .HasForeignKey(p => p.CategoryID);
            }
        }
    }
}
