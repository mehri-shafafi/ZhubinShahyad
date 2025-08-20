using Gallery.Application.Gallery.Queries.GetGalleryList;
using Gallery.Presentation.GQL.Types.Gallery;
using GraphQL.Types;
using MediatR;

namespace Gallery.Presentation.GQL.Queries
{
    public static class GalleryQueries
    {
        public static void ProductQueries(this ObjectGraphType schema, IMediator mediator)
        {
            schema.Field<ListGraphType<GalleryResType>>(
                "getProducts",
                description: "return list of prdoucts",
                resolve: context => mediator.Send(new GetGalleryListQuery())

            );

        }
    }
}
