using AutoMapper;

using News.Domain.News.Entity;
using News.Domain.News.Models;
namespace News.Infrastructure.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
          
            CreateMap<News_Article, News_ArticleModel>().ReverseMap();
            CreateMap<News_Author, News_AuthorModel>().ReverseMap();
            CreateMap<News_Category, News_CategoryModel>().ReverseMap();
        }
    }
}
