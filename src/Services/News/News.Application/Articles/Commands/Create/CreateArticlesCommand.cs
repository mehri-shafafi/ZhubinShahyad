using MediatR;
using News.Domain.Dtos.News;

namespace News.Application.Articles.Commands.Create;


public class CreateArticlesCommand : NewsArticleDto, IRequest<NewsArticleDto>
{
}