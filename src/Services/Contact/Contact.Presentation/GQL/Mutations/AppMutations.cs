using GraphQL.Types;
using MediatR;

namespace Contact.Presentation.GQL.Mutations
{
    public class AppMutations : ObjectGraphType
    {
        public AppMutations(IMediator mediator)
        {
            this.ContactMutations(mediator);
        }
    }
}
