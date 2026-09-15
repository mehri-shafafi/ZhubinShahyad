using AutoMapper;
using Products.Application.Dtos.Products;
using Products.Application.Products.Commands.Product.CreateMedical;
using Products.Application.Products.Commands.Product.UpdateProduct;
using Products.Application.Products.Queries.Product.List.GetProductsList;
using Products.Domain.Products.Entity;
using Products.Domain.Products.Models;

namespace Products.Application.Common;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        // اگر می‌خوای برای Create/Update از ProductReqDto استفاده کنی
        CreateMap<ProductModel, ProductDto>();
        CreateMap<ProductModel, ProductDetailsDto>()
            .ForMember(
                dest => dest.ImageUrls,
                opt => opt.MapFrom(src =>
                    src.ImageUrls.Select(x => new ProductImageDto
                    {
                        ImageUrl = x.ImageUrl,
                        SortOrder = x.SortOrder
                    }).ToList()
                )

            )
            .ForMember(x => x.CatalogCoverImageUrl, opt => opt.MapFrom(src => src.CatalogCoverImageUrl));

        //Create
        CreateMap<CreateProductCommand, ProductModel>()
            .ForMember(x => x.CatalogCoverImageUrl, opt => opt.MapFrom(src => src.CatalogCoverImageUrl));
        CreateMap<ProductModel, ProductEntity>()
                .ForMember(x => x.catalog_cover_image_url, opt => opt.MapFrom(src => src.CatalogCoverImageUrl))
                                                .ForMember(x => x.Id, opt => opt.Ignore())
                                                .ForMember(
                                                            desc => desc.Images,
                                                            opt => opt.MapFrom(src => src.ImageUrls.Select(x => new ProductImages
                                                            {
                                                                ImageUrl = x.ImageUrl,
                                                                SortOrder = x.SortOrder,
                                                            }).ToList()
                                                            )
                                                            );
        CreateMap<ProductModel, ProductDetailsDto>()
            .ForMember(
                dest => dest.ImageUrls,
                opt => opt.MapFrom(src =>
                    src.ImageUrls.Select(x => new ProductImageModel
                    {
                        ImageUrl = x.ImageUrl,
                        SortOrder = x.SortOrder
                    }).ToList()
                ))
            .ForMember(x => x.CatalogCoverImageUrl, opt => opt.MapFrom(src => src.CatalogCoverImageUrl));
        CreateMap<ProductModel, ProductDto>();
        CreateMap<GetProductsListQuery, ProductModel>();
        CreateMap<ProductImageModel, ProductImageDto>().ReverseMap();
        CreateMap<ProductModel, ProductDetailsDto>()
    .ForMember(
        dest => dest.CatalogCoverImageUrl,
        opt => opt.MapFrom(src => src.CatalogCoverImageUrl)
    );
        //Upadate
        CreateMap<UpdateProductCommand, UpdateProductModel>().ForAllMembers(opt =>
                                                                             opt.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<UpdateProductModel, ProductEntity>().ForMember(x => x.BrandId, opt => opt.Ignore())
                                                      .ForMember(x => x.CategoryId, opt => opt.Ignore())
                                                                                                               .ForAllMembers(opt =>
                                                                     opt.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<ProductEntity, UpdateProductModel>().ForMember(x => x.BrandId, opt => opt.Ignore())
                                                      .ForMember(x => x.CategoryId, opt => opt.Ignore())
                                                                                                             .ForAllMembers(opt =>
                                                                     opt.Condition((src, dest, srcMember) => srcMember != null));

    }
}
