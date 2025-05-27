using MediatR;

namespace News.Application.Articles.Commands.Delete;
public class DeleteArticlesCommand : IRequest<bool>
{
    public int Id { get; set; }
}