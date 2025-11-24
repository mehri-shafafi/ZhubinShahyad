namespace News.Application.Dtos.News;
public class NewsCategoryResDto : BaseEntity<int>
{
   public string Name { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool Active { get; set; } 
}