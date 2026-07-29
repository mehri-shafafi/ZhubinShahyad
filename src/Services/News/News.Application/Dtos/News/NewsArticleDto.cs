namespace News.Application.Dtos.News;

public class NewsArticleResDto : BaseEntity<int>
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

    public int AuthorID { get; set; }//شناسه نویسنده مقاله. معمولاً به جدول دیگری متصل می‌شود که اطلاعات نویسنده‌ها در آن است. (Foreign Key)
    public int CategoryID { get; set; }//شناسه دسته‌بندی مقاله. برای گروه‌بندی مقالات (مثل: علمی، خبری، آموزشی و...) استفاده می‌شود. (Foreign Key)

    public DateTime PublishedDate { get; set; }//تاریخ انتشار رسمی مقاله. معمولاً برای مشخص‌کردن زمان در دسترس قرار گرفتن مقاله استفاده می‌شود.
    public string Tags { get; set; }//برچسب‌ها یا کلیدواژه‌ها که مقاله را توصیف می‌کنند. برای جستجوی بهتر و فیلتر کردن مقالات مفید هستند.

    public string ImageURL { get; set; }//آدرس تصویر شاخص مقاله. معمولاً در کنار عنوان یا در صفحه مقاله نمایش داده می‌شود.

    public long ViewsCount { get; set; }//تعداد دفعاتی که مقاله مشاهده شده است. برای آمار و نمایش محبوب‌ترین مقالات استفاده می‌شود.

    public DateTime PostedDate { get; set; }
    //public DateTime PostedDate { get; set; }
}
