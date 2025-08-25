using GraphQL.Types;
using MediatR;

namespace Gallery.Presentation.GQL.Queries
{
    public class AppQueries: ObjectGraphType
    {
        public AppQueries(IMediator mediator)
        {
            this.GalleryQueries(mediator);
        }
    }
}
