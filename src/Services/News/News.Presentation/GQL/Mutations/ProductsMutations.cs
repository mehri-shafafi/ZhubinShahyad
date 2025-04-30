using GraphQL;
using GraphQL.Types;
using MediatR;
using News.Presentation.GQL.Types.News;
using News.Application.News.Commands.News.CreateMedical;
using News.Application.News.Commands.News.UpdateNews;
using News.Domain.Dtos.News;

namespace News.Presentation.GQL.Mutations
{
    public static class NewsMutations
    {
        public static void NewsMutations(this ObjectGraphType schema, IMediator mediator)
        {
            schema.FieldAsync<NewsResType>(
                "addNews",
                "Is used to add a new News to the database",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<NewsReqType>> { Name = "NewsInput", Description = "News input parameter" }),
                resolve: async context =>
                {
                    var addNews = context.GetArgument<CreateNewsCommand>("NewsInput");
                    NewsResDto addNewsRes = new NewsResDto();
                    try
                    {
                        addNewsRes = await mediator.Send(addNews);
                    }
                    catch (Exception ex)
                    {
                        context.Errors.Add(new ExecutionError(ex.Message));
                        return null;
                    }

                    return addNewsRes;
                }

            );
            schema.FieldAsync<BooleanGraphType>(
                "updateNews",
                "Is used to update a  News to the database",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<NewsReqType>> { Name = "NewsInput", Description = "News input parameter" }),

                resolve: async context =>
                {
                    UpdateNewsCommand updateNews = context.GetArgument<UpdateNewsCommand>("NewsInput");
                    bool updateNewsRes;
                    try
                    {
                        updateNewsRes = await mediator.Send(updateNews);
                    }
                    catch (Exception ex)
                    {

                        context.Errors.Add(new ExecutionError(ex.Message));
                        return null;

                    }

                    return updateNewsRes;
                });
        }
    }
}
