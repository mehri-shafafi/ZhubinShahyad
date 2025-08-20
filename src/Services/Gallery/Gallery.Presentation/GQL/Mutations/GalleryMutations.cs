using Gallery.Application.Gallery.Commands.Base.CreateGallery;
using Gallery.Application.Gallery.Commands.Base.UpdateGallery;
using Gallery.Domain.Dtos.Gallery;
using GraphQL;
using GraphQL.Types;
using MediatR;
using Gallery.Presentation.GQL.Types.Gallery;

namespace Products.Presentation.GQL.Mutations
{
    public static class ProductsMutations
    {
        public static void ProductMutations(this ObjectGraphType schema, IMediator mediator)
        {
            schema.FieldAsync<GalleryResType>(
                "addProduct",
                "Is used to add a new product to the database",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<GalleryReqType>> { Name = "productInput", Description = "Product input parameter" }),
                resolve: async context =>
                {
                    var addProduct = context.GetArgument<CreateGalleryCommand>("productInput");
                    GalleryResDto addProductRes = new GalleryResDto();
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
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<GalleryReqType>> { Name = "productInput", Description = "Product input parameter" }),

                resolve: async context =>
                {
                    UpdateGalleryCommand updateProduct = context.GetArgument<UpdateGalleryCommand>("productInput");
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
