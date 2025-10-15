using AutoMapper;
using Products.Application.Dtos.Products;
using Products.Application.Products.Commands.Categories.Create;
using Products.Application.Products.Commands.Categories.Update;
using Products.Domain.Products.Entity;
using Products.Domain.Products.Models;

namespace Products.Application.Common
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {

            CreateMap<ProductCategory, ProductCategoryModel>()
                                                        .ForMember
                                                                (dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                                                       .ForMember
                                                                (dest => dest.Name_FA, opt => opt.MapFrom(src => src.Name_FA))
                                                       .ForMember
                                                                (dest => dest.Name_EN, opt => opt.MapFrom(src => src.Name_EN))
                                                       .ForMember
                                                                (dest => dest.Name_AR, opt => opt.MapFrom(src => src.Name_AR))
                                                       .ForMember
                                                                (dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                                                       .ForMember
                                                                (dest => dest.Permalink, opt => opt.MapFrom(src => src.Permalink))
                                                       .ForMember
                                                                (dest => dest.Active, opt => opt.MapFrom(src => src.Active))
                                                       .ForMember
                                                                (dest => dest.Priority, opt => opt.MapFrom(src => src.Priority))
                                                       .ForMember
                                                                (dest => dest.BannerUrl, opt => opt.MapFrom(src => src.BannerUrl))
                                                       .ForMember
                                                                (dest => dest.IconUrl, opt => opt.MapFrom(src => src.IconUrl))
                                                       .ForMember
                                                                (dest => dest.ThumbnailUrl, opt => opt.MapFrom(src => src.ThumbnailUrl))
                                                                .ReverseMap();

            CreateMap<ProductCategoryDto, ProductCategoryModel>()
                                                        .ForMember
                                                                (dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                                                       .ForMember
                                                                (dest => dest.Name_FA, opt => opt.MapFrom(src => src.Name_FA))
                                                       .ForMember
                                                                (dest => dest.Name_EN, opt => opt.MapFrom(src => src.Name_EN))
                                                       .ForMember
                                                                (dest => dest.Name_AR, opt => opt.MapFrom(src => src.Name_AR))
                                                       .ForMember
                                                                (dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                                                       .ForMember
                                                                (dest => dest.Permalink, opt => opt.MapFrom(src => src.Permalink))
                                                       .ForMember
                                                                (dest => dest.Active, opt => opt.MapFrom(src => src.Active))
                                                       .ForMember
                                                                (dest => dest.Priority, opt => opt.MapFrom(src => src.Priority))
                                                       .ForMember
                                                                (dest => dest.BannerUrl, opt => opt.MapFrom(src => src.BannerUrl))
                                                       .ForMember
                                                                (dest => dest.IconUrl, opt => opt.MapFrom(src => src.IconUrl))
                                                       .ForMember
                                                                (dest => dest.ThumbnailUrl, opt => opt.MapFrom(src => src.ThumbnailUrl))
                                                                .ReverseMap();
            CreateMap<CreateCategoryCommand, ProductCategoryModel>()
                                                        .ForMember
                                                                (dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                                                       .ForMember
                                                                (dest => dest.Name_FA, opt => opt.MapFrom(src => src.Name_FA))
                                                       .ForMember
                                                                (dest => dest.Name_EN, opt => opt.MapFrom(src => src.Name_EN))
                                                       .ForMember
                                                                (dest => dest.Name_AR, opt => opt.MapFrom(src => src.Name_AR))
                                                       .ForMember
                                                                (dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                                                       .ForMember
                                                                (dest => dest.Permalink, opt => opt.MapFrom(src => src.Permalink))
                                                       .ForMember
                                                                (dest => dest.Active, opt => opt.MapFrom(src => src.Active))
                                                       .ForMember
                                                                (dest => dest.Priority, opt => opt.MapFrom(src => src.Priority))
                                                       .ForMember
                                                                (dest => dest.BannerUrl, opt => opt.MapFrom(src => src.BannerUrl))
                                                       .ForMember
                                                                (dest => dest.IconUrl, opt => opt.MapFrom(src => src.IconUrl))
                                                       .ForMember
                                                                (dest => dest.ThumbnailUrl, opt => opt.MapFrom(src => src.ThumbnailUrl))
                                                                .ReverseMap();
        }
    }

}
