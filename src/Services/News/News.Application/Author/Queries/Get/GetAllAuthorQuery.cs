using MediatR;
using News.Application.Dtos.News;

namespace News.Application.Author.Queries.Get
{
    public class GetAllAuthorQuery : IRequest<List<NewsAuthorDto>>
    {
    }
}
