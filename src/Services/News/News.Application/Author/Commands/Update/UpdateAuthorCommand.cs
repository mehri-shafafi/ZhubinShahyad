using MediatR;
using News.Application.Dtos.News;

namespace News.Application.Author.Commands.Update;

public class UpdateAuthorCommand : NewsAuthorDto, IRequest<bool>
{
    public int Id { get; set; }
}