using AutoMapper;
using News.Domain.News.Models;
using News.Domain.News.Entity;
namespace News.Infrastructure.News
{
    public class NewsMappingProfile : Profile
    {
        public NewsMappingProfile()
        {
            CreateMap<News_Article, News_ArticleModel>().ReverseMap();
            CreateMap<News_Author, News_AuthorModel>().ReverseMap();
            CreateMap<News_Category, News_CategoryModel>().ReverseMap();
        }
    }
}
