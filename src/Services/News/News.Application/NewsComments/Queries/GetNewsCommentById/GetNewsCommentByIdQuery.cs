using MediatR;
using News.Domain.Dtos.News;

namespace News.Application.NewsComments.Queries.GetNewsCommentById
{
    public class GetArticlesByIdQuery : IRequest<NewsCommentDto>
    {
        public int NewsCommentId { get; set; }
    }
}
