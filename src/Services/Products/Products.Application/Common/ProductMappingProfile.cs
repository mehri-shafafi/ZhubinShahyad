using AutoMapper;
using Products.Application.Dtos.Products;
using Products.Domain.Products.Entity;
using Products.Domain.Products.Models;
namespace Products.Application.Products
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


            CreateMap<ProductModel, ProductDto>()
                                                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductId))
                                                .ForMember(dest => dest.Name_FA, opt => opt.MapFrom(src => src.Name_FA))
                                                .ForMember(dest => dest.Name_EN, opt => opt.MapFrom(src => src.Name_EN))
                                                .ForMember(dest => dest.Name_AR, opt => opt.MapFrom(src => src.Name_AR))
                                                .ForMember(dest => dest.Description_FA, opt => opt.MapFrom(src => src.Description_FA))
                                                .ForMember(dest => dest.Description_EN, opt => opt.MapFrom(src => src.Description_EN))
                                                .ForMember(dest => dest.Description_AR, opt => opt.MapFrom(src => src.Description_AR))
                                                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                                                .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.BrandId))
                                                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                                                .ForMember(dest => dest.StockQuantity, opt => opt.MapFrom(src => src.StockQuantity))
                                                .ForMember(dest => dest.SKU, opt => opt.MapFrom(src => src.SKU))
                                                .ForMember(dest => dest.CatalogURL, opt => opt.MapFrom(src => src.CatalogURL))
                                                .ForMember(dest => dest.CatalogCoverImageUrl, opt => opt.MapFrom(src => src.CatalogCoverImageUrl))
                                                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating))
                                                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.BrandName))
                                                .ForMember(dest => dest.CategoryName_FA, opt => opt.MapFrom(src => src.CategoryName_FA))
                                                .ForMember(dest => dest.CategoryName_EN, opt => opt.MapFrom(src => src.CategoryName_EN))
                                                .ForMember(dest => dest.CategoryName_AR, opt => opt.MapFrom(src => src.CategoryName_AR))
                                                .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.ImageUrls));

        }
    }
}
