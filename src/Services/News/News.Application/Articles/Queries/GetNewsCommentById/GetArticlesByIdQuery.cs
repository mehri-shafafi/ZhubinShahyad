using MediatR;
using News.Application.Dtos.News;

namespace News.Application.Articles.Queries.GetNewsCommentById
{
    public class GetArticlesByIdQuery : IRequest<NewsArticleResDto>
    {
        public int Id { get; set; }
    }
}
