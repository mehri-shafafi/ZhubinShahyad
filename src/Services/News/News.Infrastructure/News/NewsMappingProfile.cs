using News.Domain.Dtos.News;
using AutoMapper;
using News.Domain.News.Models;
namespace News.Infrastructure.News
{
    public class NewsMappingProfile : Profile
    {
        public NewsMappingProfile()
        {
            CreateMap<News_Article, NewsArticleResDto>().ReverseMap();
            CreateMap<News_Author, NewsAuthorDto>().ReverseMap();
            CreateMap<News_Category, NewsCategoryDto>().ReverseMap();
        }
    }
}
