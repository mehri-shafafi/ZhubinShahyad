using MediatR;
using News.Domain.Dtos.News;

namespace News.Application.Articles.Commands.Update;

public class UpdateArticleCommand : NewsArticleDto, IRequest<bool>
{
    public int Id { get; set; }
}