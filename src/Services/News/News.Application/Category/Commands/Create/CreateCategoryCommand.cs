using MediatR;
using News.Domain.Dtos.News;

namespace News.Application.Category.Commands.Create;


public class CreateCategoryCommand : NewsCategoryDto, IRequest<NewsCategoryDto>
{
}