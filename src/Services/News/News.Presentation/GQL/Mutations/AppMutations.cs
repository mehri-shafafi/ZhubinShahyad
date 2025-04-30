using GraphQL.Types;
using MediatR;

namespace News.Presentation.GQL.Mutations
{
    public class AppMutations:ObjectGraphType
    {
        public AppMutations(IMediator mediator)
        {
            this.NewsMutations(mediator);
        }
    }
}
