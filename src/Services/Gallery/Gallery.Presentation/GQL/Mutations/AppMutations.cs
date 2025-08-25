using GraphQL.Types;
using MediatR;

namespace Gallery.Presentation.GQL.Mutations
{
    public class AppMutations:ObjectGraphType
    {
        public AppMutations(IMediator mediator)
        {
            this.GalleryMutations(mediator);
        }
    }
}
