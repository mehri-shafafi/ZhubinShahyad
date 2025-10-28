using MediatR;
using News.Application.Dtos.News;

namespace News.Application.Articles.Commands.Create;


public class CreateArticlesCommand : NewsArticleResDto, IRequest<bool>
{
}