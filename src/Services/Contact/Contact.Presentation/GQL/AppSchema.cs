using Contact.Presentation.GQL.Mutations;
using Contact.Presentation.GQL.Queries;
using GraphQL.Types;

namespace Contact.Presentation.GQL
{
    public class AppSchema : Schema
    {
        public AppSchema(AppQueries appQueries, AppMutations appMutations)
        {
            this.Query = appQueries;
            this.Mutation = appMutations;
        }
    }
}
