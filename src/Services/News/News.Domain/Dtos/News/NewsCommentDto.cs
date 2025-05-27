using News.Domain.Base;

namespace News.Domain.Dtos.News;
public class NewsCommentResDto:NewsCommentDto
{
    public int NewsArticleTitle { get; set; }
    public string Content { get; set; }
    public DateTime PostedDate { get; set; }
    //public DateTime PostedDate { get; set; }
}
public class NewsCommentDto:BaseEntity<int>
{
    public int NewsArticleID { get; set; }
    public string Content { get; set; }
    public DateTime PostedDate { get; set; }
    //public DateTime PostedDate { get; set; }
}
