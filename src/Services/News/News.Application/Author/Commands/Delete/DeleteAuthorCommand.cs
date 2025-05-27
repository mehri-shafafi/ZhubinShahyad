using MediatR;

namespace News.Application.Author.Commands.Delete;
public class DeleteAuthorCommand : IRequest<bool>
{
    public int Id { get; set; }
}