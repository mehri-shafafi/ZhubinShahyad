using News.Domain.Base;

namespace News.Domain.News.Models
{
    public class News_AuthorModel : BaseEntity<int>
    {
        public string Name { get; set; }

        public string Bio { get; set; }
        public string ProfilePictureURL { get; set; }

    }
}
