using GraphQL;
using GraphQL.Types;
using MediatR;
using News.Application.News.Queries.News.GetNewsList;
using News.Presentation.GQL.Types;
using News.Presentation.GQL.Types.News;

namespace News.Presentation.GQL.Queries
{
    public static class NewsQueries
    {
        public static void NewsQueries(this ObjectGraphType schema, IMediator mediator)
        {
            schema.Field<ListGraphType<NewsResType>>(
                "getNews",
                description: "return list of prdoucts",
                resolve: context => mediator.Send(new GetNewsListQuery())

            );
            schema.FieldAsync<PaginationResType<ListGraphType<NewsResType>>>(
                "getNewsByFilter",
                description: "return list of filtered prdoucts",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<NewsFilterType>> { Name = "filter" }),


                resolve: async context =>
                {
                    var filterParams = context.GetArgument<GetNewsListQuery>("filter");
                    var res = await mediator.Send(filterParams);

                    return res;
                });
        }
    }
}
