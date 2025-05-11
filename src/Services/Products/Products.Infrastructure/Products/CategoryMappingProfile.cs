using AutoMapper;
using Products.Domain.Dtos.Products;
using Products.Domain.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Infrastructure.Products
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();
            //CreateMap<ProductCategory, ProductCategoryDto>();
        }
    }

}
