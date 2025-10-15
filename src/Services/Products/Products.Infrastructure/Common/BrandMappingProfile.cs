using AutoMapper;
using Products.Domain.Products.Entity;
using Products.Domain.Products.Models;

namespace Products.Infrastructure.Common
{
    public class BrandMappingProfile : Profile
    {
        public BrandMappingProfile()
        {

            CreateMap<ProductBrand, ProductBrandModel>()
                                                       .ForMember
                                                                (dest => dest.Id, opt => opt.MapFrom(src => src.Id))  
                                                                .ForMember
                                                                (dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                                                       .ForMember
                                                                (dest => dest.LogoURL, opt => opt.MapFrom(src => src.LogoURL))
                                                       .ForMember
                                                                (dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                                                                .ReverseMap();


            //CreateMap<ProductBrandModel, ProductBrandDto>()
            //                                           .ForMember
            //                                                    (dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            //                                           .ForMember
            //                                                    (dest => dest.LogoURL, opt => opt.MapFrom(src => src.LogoURL))
            //                                           .ForMember
            //                                                    (dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            //                                                    .ReverseMap();
        }
    }
}
