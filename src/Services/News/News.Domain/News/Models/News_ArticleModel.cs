using News.Domain.Base;

namespace News.Domain.News.Models
{
    public class News_ArticleModel : BaseEntity<int>
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
        public News_AuthorModel news_AuthorModel { get; set; } // Navigation property
        public News_CategoryModel news_CategoryModel { get; set; } // Navigation property
    }
}
