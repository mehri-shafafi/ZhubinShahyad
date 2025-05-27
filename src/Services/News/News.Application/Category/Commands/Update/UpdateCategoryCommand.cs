using MediatR;
using News.Domain.Dtos.News;

namespace News.Application.Category.Commands.Update;

public class UpdateCategoryCommand : NewsCategoryDto, IRequest<bool>
{
    public int Id { get; set; }
}