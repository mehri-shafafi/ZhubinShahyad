using AutoMapper;
using Products.Domain.Products.Entity;
using Products.Domain.Products.Models;
namespace Products.Infrastructure.Common;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        // اگر می‌خوای برای Create/Update از ProductReqDto استفاده کنی
        CreateMap<ProductEntity, ProductModel>();

        CreateMap<ProductEntity, ProductModel>();
    }
}
