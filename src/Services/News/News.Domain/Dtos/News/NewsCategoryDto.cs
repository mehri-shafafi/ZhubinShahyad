namespace News.Domain.Dtos.News;
public class NewsCategoryDto
{
   public string Name { get; set; }
    public string Description { get; set; }
    public int ParentCategoryID { get; set; }
    public string Slug { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}