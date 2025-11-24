using MediatR;
using News.Application.Dtos.News;

namespace News.Application.Category.Commands.Update;

public class UpdateCategoryCommand : NewsCategoryResDto, IRequest<bool>
{
    public int Id { get; set; }
}