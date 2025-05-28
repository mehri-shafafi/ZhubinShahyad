using MediatR;
using News.Domain.Dtos.News;

namespace News.Application.Author.Commands.Create;


public class CreateAuthorCommand : NewsAuthorDto, IRequest<NewsAuthorDto>
{
}