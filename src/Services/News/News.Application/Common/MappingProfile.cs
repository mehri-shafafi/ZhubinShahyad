using AutoMapper;
using News.Application.Articles.Commands.Update;
using News.Application.Category.Commands.Create;
using News.Application.Dtos.News;
using News.Domain.News.Entity;
using News.Domain.News.Models;
namespace News.Application.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {


            CreateMap<Domain.News.Entity.Author, News_AuthorModel>().ReverseMap();
            CreateMap<NewsAuthorDto, News_AuthorModel>().ReverseMap();
            CreateMap<Domain.News.Entity.Category, News_CategoryModel>().ReverseMap();

            #region Article
            CreateMap<Article, News_ArticleModel>()
                                            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                                            .ForMember(dest => dest.Title_FA, opt => opt.MapFrom(src => src.Title_FA))
                                            .ForMember(dest => dest.Summary_FA, opt => opt.MapFrom(src => src.Summary_FA))
                                            .ForMember(dest => dest.Content_FA, opt => opt.MapFrom(src => src.Content_FA))
                                            .ForMember(dest => dest.Title_EN, opt => opt.MapFrom(src => src.Title_EN))
                                            .ForMember(dest => dest.Summary_EN, opt => opt.MapFrom(src => src.Summary_EN))
                                            .ForMember(dest => dest.Content_EN, opt => opt.MapFrom(src => src.Content_EN))
                                            .ForMember(dest => dest.Title_AR, opt => opt.MapFrom(src => src.Title_AR))
                                            .ForMember(dest => dest.Summary_AR, opt => opt.MapFrom(src => src.Summary_AR))
                                            .ForMember(dest => dest.Content_AR, opt => opt.MapFrom(src => src.Content_AR))
                                            .ForMember(dest => dest.AuthorID, opt => opt.MapFrom(src => src.AuthorID))
                                            .ForMember(dest => dest.CategoryID, opt => opt.MapFrom(src => src.CategoryID))
                                            .ForMember(dest => dest.PublishedDate, opt => opt.MapFrom(src => src.PublishedDate))
                                            .ForMember(dest => dest.ImageURL, opt => opt.MapFrom(src => src.ImageURL))
                                            .ForMember(dest => dest.ViewsCount, opt => opt.MapFrom(src => src.ViewsCount))
                                            .ReverseMap();
            CreateMap<NewsArticleResDto, News_ArticleModel>()
                                            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                                            .ForMember(dest => dest.Title_FA, opt => opt.MapFrom(src => src.Title_FA))
                                            .ForMember(dest => dest.Summary_FA, opt => opt.MapFrom(src => src.Summary_FA))
                                            .ForMember(dest => dest.Content_FA, opt => opt.MapFrom(src => src.Content_FA))
                                            .ForMember(dest => dest.Title_EN, opt => opt.MapFrom(src => src.Title_EN))
                                            .ForMember(dest => dest.Summary_EN, opt => opt.MapFrom(src => src.Summary_EN))
                                            .ForMember(dest => dest.Content_EN, opt => opt.MapFrom(src => src.Content_EN))
                                            .ForMember(dest => dest.Title_AR, opt => opt.MapFrom(src => src.Title_AR))
                                            .ForMember(dest => dest.Summary_AR, opt => opt.MapFrom(src => src.Summary_AR))
                                            .ForMember(dest => dest.Content_AR, opt => opt.MapFrom(src => src.Content_AR))
                                            .ForMember(dest => dest.AuthorID, opt => opt.MapFrom(src => src.AuthorID))
                                            .ForMember(dest => dest.CategoryID, opt => opt.MapFrom(src => src.CategoryID))
                                            .ForMember(dest => dest.PublishedDate, opt => opt.MapFrom(src => src.PublishedDate))
                                            .ForMember(dest => dest.ImageURL, opt => opt.MapFrom(src => src.ImageURL))
                                            .ForMember(dest => dest.ViewsCount, opt => opt.MapFrom(src => src.ViewsCount))
                                            .ReverseMap();
            //CreateMap<News_ArticleModel, UpdateArticleCommand>()
            //                                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //                                .ForMember(dest => dest.Title_FA, opt => opt.MapFrom(src => src.Title_FA))
            //                                .ForMember(dest => dest.Summary_FA, opt => opt.MapFrom(src => src.Summary_FA))
            //                                .ForMember(dest => dest.Content_FA, opt => opt.MapFrom(src => src.Content_FA))
            //                                .ForMember(dest => dest.Title_EN, opt => opt.MapFrom(src => src.Title_EN))
            //                                .ForMember(dest => dest.Summary_EN, opt => opt.MapFrom(src => src.Summary_EN))
            //                                .ForMember(dest => dest.Content_EN, opt => opt.MapFrom(src => src.Content_EN))
            //                                .ForMember(dest => dest.Title_AR, opt => opt.MapFrom(src => src.Title_AR))
            //                                .ForMember(dest => dest.Summary_AR, opt => opt.MapFrom(src => src.Summary_AR))
            //                                .ForMember(dest => dest.Content_AR, opt => opt.MapFrom(src => src.Content_AR))
            //                                .ForMember(dest => dest.AuthorID, opt => opt.MapFrom(src => src.AuthorID))
            //                                .ForMember(dest => dest.CategoryID, opt => opt.MapFrom(src => src.CategoryID))
            //                                .ForMember(dest => dest.PublishedDate, opt => opt.MapFrom(src => src.PublishedDate))
            //                                .ForMember(dest => dest.ImageURL, opt => opt.MapFrom(src => src.ImageURL))
            //                                .ForMember(dest => dest.ViewsCount, opt => opt.MapFrom(src => src.ViewsCount))
            //                                .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active))
            //                                 .ReverseMap();

            CreateMap<UpdateNewsRequestDto, UpdateNewsCommand>()
                                            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                                            .ForMember(dest => dest.Title_FA, opt => opt.MapFrom(src => src.Title_FA))
                                            .ForMember(dest => dest.Summary_FA, opt => opt.MapFrom(src => src.Summary_FA))
                                            .ForMember(dest => dest.Content_FA, opt => opt.MapFrom(src => src.Content_FA))
                                            .ForMember(dest => dest.Title_EN, opt => opt.MapFrom(src => src.Title_EN))
                                            .ForMember(dest => dest.Summary_EN, opt => opt.MapFrom(src => src.Summary_EN))
                                            .ForMember(dest => dest.Content_EN, opt => opt.MapFrom(src => src.Content_EN))
                                            .ForMember(dest => dest.Title_AR, opt => opt.MapFrom(src => src.Title_AR))
                                            .ForMember(dest => dest.Summary_AR, opt => opt.MapFrom(src => src.Summary_AR))
                                            .ForMember(dest => dest.Content_AR, opt => opt.MapFrom(src => src.Content_AR))
                                            .ForMember(dest => dest.AuthorID, opt => opt.MapFrom(src => src.AuthorID))
                                            .ForMember(dest => dest.CategoryID, opt => opt.MapFrom(src => src.CategoryID))
                                            .ForMember(dest => dest.PublishedDate, opt => opt.MapFrom(src => src.PublishedDate))
                                            .ForMember(dest => dest.ImageURL, opt => opt.MapFrom(src => src.ImageURL))
                                            .ForMember(dest => dest.ViewsCount, opt => opt.MapFrom(src => src.ViewsCount))
                                            .ReverseMap();
            CreateMap<ChangeNewsArticleStatusModel, ChangeNewsArticleStatusCommand>()
                                            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                                            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                                                                                     .ReverseMap();
            #endregion

            #region categories
            CreateMap<NewsCategoryResDto, News_CategoryModel>()
                                         .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                                         .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                                         .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                                         .ForMember(dest => dest.Slug, opt => opt.MapFrom(src => src.Slug))
                                         .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
                                         .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => src.UpdatedDate))
                                         .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active))
                                                                                .ReverseMap();
            #endregion
        }
    }
}
