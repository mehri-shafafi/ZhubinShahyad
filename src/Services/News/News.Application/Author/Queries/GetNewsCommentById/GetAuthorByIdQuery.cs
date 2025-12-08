using MediatR;
using News.Application.Dtos.News;

namespace News.Application.Author.Queries.GetNewsCommentById
{
    public class GetAuthorByIdQuery : IRequest<NewsAuthorDto>
    {
        public int Id { get; set; }
    }
}
