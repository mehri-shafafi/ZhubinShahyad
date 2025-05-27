using MediatR;
using News.Domain.Dtos.News;

namespace News.Application.NewsComments.Queries.GetAllNewsComments
{
    public class GetAllNewsCommentsQuery : IRequest<List<NewsCommentDto>>
    {

    }
}
