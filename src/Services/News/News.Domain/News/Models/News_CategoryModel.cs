using News.Domain.Base;

namespace News.Domain.News.Models
{
    public class News_CategoryModel : BaseEntity
    {
        public string Name { get; set; }//نام دسته‌بندی (مثلاً "اخبار صنعت پزشکی" یا "معرفی محصولات جدید").
        public string Description { get; set; }

        public string Slug { get; set; }   //آدرس یکتا برای دسته‌بندی که در URL استفاده می‌شود (مثلاً "medical-news" برای دسته‌بندی اخبار پزشکی).
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Active { get; set; }
        public ICollection<News_ArticleModel> news_ArticlesModel { get; set; } // Navigation property


    }
}
