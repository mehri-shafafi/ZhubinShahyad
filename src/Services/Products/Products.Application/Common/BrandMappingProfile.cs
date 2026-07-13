using AutoMapper;
using Products.Application.Dtos.Brands;
using Products.Application.Products.Commands.Categories.Update;
using Products.Domain.Products.Entity;
using Products.Domain.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Common
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


            CreateMap<ProductBrandModel, ProductBrandDto>()
                                                        .ForMember
                                                                (dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                                                       .ForMember
                                                                (dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                                                       .ForMember
                                                                (dest => dest.LogoURL, opt => opt.MapFrom(src => src.LogoURL))
                                                       .ForMember
                                                                (dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                                                                .ReverseMap();

            CreateMap<UpdateBrandCommand, ProductBrandModel>()
                                                        .ForMember
                                                                (dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                                                       .ForMember
                                                                (dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                                                       .ForMember
                                                                (dest => dest.LogoURL, opt => opt.MapFrom(src => src.LogoURL))
                                                       .ForMember
                                                                (dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                                                                .ReverseMap();
        }
    }
}
