namespace News.Application.Dtos.News;
public class NewsAuthorDto : BaseEntity<int>
{
    public string Name { get; set; }
    public string Bio { get; set; }
    public string ProfilePictureURL  {get; set; }
}

   