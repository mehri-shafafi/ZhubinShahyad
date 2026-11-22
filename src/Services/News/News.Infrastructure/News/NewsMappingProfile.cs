using AutoMapper;
using News.Domain.News.Models;
using News.Domain.News.Entity;
namespace News.Infrastructure.News
{
    public class NewsMappingProfile : Profile
    {
        public NewsMappingProfile()
        {
            CreateMap<Article, News_ArticleModel>().ReverseMap();
            CreateMap<Author, News_AuthorModel>().ReverseMap();
            CreateMap<Category, News_CategoryModel>().ReverseMap();
        }
    }
}
