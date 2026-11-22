using AutoMapper;

using News.Domain.News.Entity;
using News.Domain.News.Models;
namespace News.Infrastructure.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
          
            CreateMap<Article, News_ArticleModel>().ReverseMap();
            CreateMap<Author, News_AuthorModel>().ReverseMap();
            CreateMap<Category, News_CategoryModel>().ReverseMap();
        }
    }
}
