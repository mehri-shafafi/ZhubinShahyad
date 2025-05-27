using MediatR;
using News.Domain.Dtos.News;

namespace News.Application.NewsComments.Queries.GetAllNewsComments
{
    public class GetAllArticlesQuery : IRequest<List<NewsCommentDto>>
    {

    }
}
