using MediatR;
using News.Application.Dtos.News;

namespace News.Application.Author.Queries.Get
{
    public class GetCategoryByIdQuery : IRequest<NewsAuthorDto>
    {
        public int Id { get; set; }
    }
}
