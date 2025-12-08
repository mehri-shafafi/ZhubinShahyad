using MediatR;
using News.Application.Dtos.News;

namespace News.Application.Author.Commands.Create;


public class CreateAuthorCommand : NewsAuthorDto, IRequest<bool>
{
}