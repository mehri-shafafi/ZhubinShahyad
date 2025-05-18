using GraphQL;
using GraphQL.Types;
using MediatR;
using Menus.Application.Menu.Commands.Menu.Create;
using Menus.Application.Menus.Commands.Menu.UpdateMenu;
using Menus.Domain.Dtos.Menu;
using Products.Presentation.GQL.Types.Products;

namespace Products.Presentation.GQL.Mutations
{
    public static class ProductsMutations
    {
        public static void ProductMutations(this ObjectGraphType schema, IMediator mediator)
        {
            schema.FieldAsync<ProductResType>(
                "addProduct",
                "Is used to add a new product to the database",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ProductReqType>> { Name = "productInput", Description = "Product input parameter" }),
                resolve: async context =>
                {
                    var addProduct = context.GetArgument<CreateMenuCommand>("productInput");
                    MenuResDto addProductRes = new MenuResDto();
                    try
                    {
                        addProductRes = await mediator.Send(addProduct);
                    }
                    catch (Exception ex)
                    {
                        context.Errors.Add(new ExecutionError(ex.Message));
                        return null;
                    }

                    return addProductRes;
                }

            );
            schema.FieldAsync<BooleanGraphType>(
                "updateProduct",
                "Is used to update a  product to the database",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ProductReqType>> { Name = "productInput", Description = "Product input parameter" }),

                resolve: async context =>
                {
                    UpdateMenuCommand updateProduct = context.GetArgument<UpdateMenuCommand>("productInput");
                    bool updateProductRes;
                    try
                    {
                        updateProductRes = await mediator.Send(updateProduct);
                    }
                    catch (Exception ex)
                    {

                        context.Errors.Add(new ExecutionError(ex.Message));
                        return null;

                    }

                    return updateProductRes;
                });
        }
    }
}
