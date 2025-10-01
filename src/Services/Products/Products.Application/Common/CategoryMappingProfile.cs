using AutoMapper;
using Products.Domain.Products.Entity;
using Products.Domain.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Products
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
