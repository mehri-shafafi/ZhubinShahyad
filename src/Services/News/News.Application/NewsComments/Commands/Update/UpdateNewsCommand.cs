using MediatR;
using News.Domain.Dtos.News;

namespace News.Application.News.Commands.News.Update;

public class UpdateNewsCommand : NewsCommentDto, IRequest<bool>
{
    public int NewsCommentId { get; set; }
}