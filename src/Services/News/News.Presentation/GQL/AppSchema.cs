using GraphQL.Types;
using News.Presentation.GQL.Mutations;
using News.Presentation.GQL.Queries;

namespace News.Presentation.GQL
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
