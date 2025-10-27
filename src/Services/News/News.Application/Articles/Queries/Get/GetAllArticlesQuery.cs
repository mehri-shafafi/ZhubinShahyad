using MediatR;
using News.Application.Dtos.News;

namespace News.Application.Articles.Queries.Get
{
    public class GetAllArticlesQuery : IRequest<List<NewsArticleResDto>>
    {

    }
}
