using MediatR;
using News.Domain.Dtos.News;

namespace News.Application.Author.Queries.Get
{
    public class GetAllCategoryQuery : IRequest<List<NewsAuthorDto>>
    {

    }
}
