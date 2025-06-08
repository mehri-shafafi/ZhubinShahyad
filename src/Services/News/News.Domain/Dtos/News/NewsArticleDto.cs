using News.Domain.Base;

namespace News.Domain.Dtos.News;

public class NewsArticleResDto:BaseEntity<int>
{
    public string Title { get; set; } //عنوان مقاله. چیزی که به صورت تیتر در لیست مقالات یا در ابتدای صفحه دیده می‌شود.

    public string Summary { get; set; }//خلاصه‌ای کوتاه از مقاله. برای نمایش در فهرست‌ها یا پیش‌نمایش استفاده می‌شود.
    public string Content { get; set; }//محتوای کامل مقاله. متن اصلی مقاله در این فیلد ذخیره می‌شود.

    public int AuthorID { get; set; }//شناسه نویسنده مقاله. معمولاً به جدول دیگری متصل می‌شود که اطلاعات نویسنده‌ها در آن است. (Foreign Key)
    public int CategoryID { get; set; }//شناسه دسته‌بندی مقاله. برای گروه‌بندی مقالات (مثل: علمی، خبری، آموزشی و...) استفاده می‌شود. (Foreign Key)

    public DateTime PublishedDate { get; set; }//تاریخ انتشار رسمی مقاله. معمولاً برای مشخص‌کردن زمان در دسترس قرار گرفتن مقاله استفاده می‌شود.
    public string Tags { get; set; }//برچسب‌ها یا کلیدواژه‌ها که مقاله را توصیف می‌کنند. برای جستجوی بهتر و فیلتر کردن مقالات مفید هستند.

    public string ImageURL { get; set; }//آدرس تصویر شاخص مقاله. معمولاً در کنار عنوان یا در صفحه مقاله نمایش داده می‌شود.

    public long ViewsCount { get; set; }//تعداد دفعاتی که مقاله مشاهده شده است. برای آمار و نمایش محبوب‌ترین مقالات استفاده می‌شود.

    public DateTime PostedDate { get; set; }
    //public DateTime PostedDate { get; set; }
}
