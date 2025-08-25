using Gallery.Presentation.GQL.Mutations;
using Gallery.Presentation.GQL.Queries;
using GraphQL.Types;

namespace Gallery.Presentation.GQL
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
