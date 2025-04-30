using GraphQL.Types;
using MediatR;

namespace News.Presentation.GQL.Queries
{
    public class AppQueries: ObjectGraphType
    {
        public AppQueries(IMediator mediator)
        {
            this.NewsQueries(mediator);
        }
    }
}
