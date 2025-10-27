using MediatR;
using News.Application.Dtos.News;

namespace News.Application.Category.Commands.Create;


public class CreateCategoryCommand : NewsCategoryDto, IRequest<NewsCategoryDto>
{
}