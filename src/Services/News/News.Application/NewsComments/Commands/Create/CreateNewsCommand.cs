using MediatR;
using News.Domain.Dtos.News;

namespace News.Application.NewsCommands.Commands.Create;


public class CreateNewsCommand : NewsCommentDto, IRequest<NewsCommentDto>
{
}