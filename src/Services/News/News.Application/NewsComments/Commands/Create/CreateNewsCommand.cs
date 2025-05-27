using MediatR;
using News.Domain.Dtos.News;

namespace News.Application.NewsCommands.Commands.Create;


public class CreateArticlesCommand : NewsCommentDto, IRequest<NewsCommentDto>
{
}