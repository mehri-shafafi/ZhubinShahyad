using MediatR;
using News.Domain.Dtos.News;

namespace News.Application.Articles.Queries.Get
{
    public class GetAllArticlesQuery : IRequest<List<NewsArticleDto>>
    {

    }
}
