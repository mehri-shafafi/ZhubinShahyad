using MediatR;
using News.Domain.Dtos.News;

namespace News.Application.Articles.Commands.Create;


public class CreateAuthorCommand : NewsArticleDto, IRequest<NewsArticleDto>
{
}