using Gallery.Application.Gallery.Commands.Base.CreateGallery;
using Gallery.Application.Gallery.Commands.Base.UpdateGallery;
using Gallery.Domain.Dtos.Gallery;
using Gallery.Presentation.GQL.Types.Gallery;
using GraphQL;
using GraphQL.Types;
using MediatR;

namespace Gallery.Presentation.GQL.Mutations
{
    public static class GalleriesMutations
    {
        public static void GalleryMutations(this ObjectGraphType schema, IMediator mediator)
        {
            schema.FieldAsync<GalleryResType>(
                "addGallery",
                "Is used to add a new Gallery to the database",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<GalleryReqType>> { Name = "GalleryInput", Description = "Gallery input parameter" }),
                resolve: async context =>
                {
                    var addProduct = context.GetArgument<CreateGalleryCommand>("GalleryInput");
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
