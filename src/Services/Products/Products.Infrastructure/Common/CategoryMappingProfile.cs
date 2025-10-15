using AutoMapper;
using Products.Domain.Products.Entity;
using Products.Domain.Products.Models;

namespace Products.Infrastructure.Common
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<ProductCategory, ProductCategoryModel>().ReverseMap();
            //CreateMap<ProductCategory, ProductCategoryDto>();
        }
    }

}
