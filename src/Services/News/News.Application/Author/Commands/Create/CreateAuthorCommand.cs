using MediatR;
using News.Domain.Dtos.News;

namespace News.Application.Author.Commands.Create;


public class CreateCategoryCommand : NewsAuthorDto, IRequest<NewsAuthorDto>
{
}