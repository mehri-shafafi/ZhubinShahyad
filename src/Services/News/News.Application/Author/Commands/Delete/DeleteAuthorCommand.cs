using MediatR;

namespace News.Application.Author.Commands.Delete;
public class DeleteCategoryCommand : IRequest<bool>
{
    public int Id { get; set; }
}