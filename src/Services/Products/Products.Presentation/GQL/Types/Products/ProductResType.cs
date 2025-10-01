using GraphQL.Types;
using Products.Application.Dtos.Products;

namespace Products.Presentation.GQL.Types.Products
{
    public class ProductResType : ObjectGraphType<ProductResDto>
    {

        public ProductResType()
        {
            Field(x => x.Id, type: typeof(IdGraphType));
            Field(x => x.Name_AR, type: typeof(StringGraphType));
            Field(x => x.Name_EN, type: typeof(StringGraphType));
            Field(x => x.Name_FA, type: typeof(StringGraphType));
            Field(x => x.Description_EN, type: typeof(StringGraphType));
            Field(x => x.Description_AR, type: typeof(StringGraphType));
            Field(x => x.Description_FA, type: typeof(StringGraphType));
            Field(x => x.ImageUrls, type: typeof(StringGraphType));
            Field(x => x.Price, type: typeof(DecimalGraphType));
            Field(x => x.BrandId, type: typeof(IntGraphType));
            Field(x => x.CategoryId, type: typeof(IntGraphType));
            Field(x => x.StockQuantity, type: typeof(BooleanGraphType));
            Field(x => x.SKU, type: typeof(StringGraphType));
            Field(x => x.ImageUrls, type: typeof(IntGraphType));
            Field(x => x.Warranty, type: typeof(IntGraphType));
            Field(x => x.Rating, type: typeof(IntGraphType));
        }
    }
}
