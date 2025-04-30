using MediatR;

namespace News.Application.NewsCommands.Commands.Delete;
public class DeleteNewsCommand : IRequest<bool>
{
    public int Id { get; set; }
}