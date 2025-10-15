using AutoMapper;
using Products.Domain.Products.Entity;
using Products.Domain.Products.Models;
namespace Products.Infrastructure.Common
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            // اگر می‌خوای برای Create/Update از ProductReqDto استفاده کنی
            CreateMap<ProductEntity, ProductModel>().ReverseMap();

            CreateMap<ProductEntity, ProductModel>()
                                                      .ForMember(dest => dest.BrandName,
                                                         opt => opt.MapFrom(src => src.ProductBrand != null ? src.ProductBrand.Name : null))
                                                     .ForMember(dest => dest.CategoryName_FA,
                                                         opt => opt.MapFrom(src => src.Category != null ? src.Category.Name_FA : null))
                                                     .ForMember(dest => dest.CategoryName_EN,
                                                         opt => opt.MapFrom(src => src.Category != null ? src.Category.Name_EN : null))
                                                     .ForMember(dest => dest.CategoryName_AR,
                                                         opt => opt.MapFrom(src => src.Category != null ? src.Category.Name_AR : null))
                                                     .ForMember(dest => dest.ImageUrls,
                                                         opt => opt.MapFrom(src => src.Images != null
                                                             ? src.Images.Select(i => i.ImageUrl).ToList()
                                                             : new List<string>()))
                                                     .ForMember(dest => dest.ProductId,
                                                         opt => opt.MapFrom(src => src.Id))
                                                     .ForMember(dest => dest.CatalogCoverImageUrl,
                                                         opt => opt.MapFrom(src => src.catalog_cover_image_url))
                                                     .ReverseMap();


            

        }
    }
}
