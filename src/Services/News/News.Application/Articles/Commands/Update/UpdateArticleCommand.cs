using MediatR;
using News.Domain.Dtos.News;

namespace News.Application.Articles.Commands.Update;

public class UpdateArticleCommand : NewsArticleResDto, IRequest<bool>
{
    public int Id { get; set; }
}