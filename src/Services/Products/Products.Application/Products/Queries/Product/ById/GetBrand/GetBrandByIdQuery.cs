using MediatR;
using Products.Application.Dtos.Brands;

namespace Products.Application.Products.Queries.Product.ById.GetBrand;

public class GetBrandByIdQuery :  IRequest<BrandDto>
{
    public int BrandId { get; set; }
}
