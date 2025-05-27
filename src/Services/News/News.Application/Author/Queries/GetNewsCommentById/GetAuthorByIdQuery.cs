using MediatR;
using News.Domain.Dtos.News;

namespace News.Application.Author.Queries.Get
{
    public class GetCategoryByIdQuery : IRequest<NewsAuthorDto>
    {
        public int Id { get; set; }
    }
}
