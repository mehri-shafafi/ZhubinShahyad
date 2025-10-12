using Gallery.Presentation.GQL.Queries;
using GraphQL.Types;
using MediatR;

namespace Contact.Presentation.GQL.Queries
{
    public class AppQueries: ObjectGraphType
    {
        public AppQueries(IMediator mediator)
        {
            this.ContactQueries(mediator);
        }
    }
}
