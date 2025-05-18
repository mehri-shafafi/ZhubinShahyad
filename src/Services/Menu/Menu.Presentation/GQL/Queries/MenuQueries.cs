using GraphQL;
using GraphQL.Types;
using MediatR;
using Menus.Application.Menus.Queries.Menu.GetMenusList;
using Menus.Presentation.GQL.Types.Menu;
using Products.Presentation.GQL.Types;
using Products.Presentation.GQL.Types.Products;

namespace Products.Presentation.GQL.Queries
{
    public static class ProductsQueries
    {
        public static void ProductQueries(this ObjectGraphType schema, IMediator mediator)
        {
            schema.Field<ListGraphType<MenuResType>>(
                "getProducts",
                description: "return list of prdoucts",
                resolve: context => mediator.Send(new GetMenusListQuery())

            );
            schema.FieldAsync<PaginationResType<ListGraphType<MenuResType>>>(
                "getProductsByFilter",
                description: "return list of filtered prdoucts",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ProductFilterType>> { Name = "filter" }),


                resolve: async context =>
                {
                    var filterParams = context.GetArgument<GetMenusListQuery>("filter");
                    var res = await mediator.Send(filterParams);

                    return res;
                });
        }
    }
}
