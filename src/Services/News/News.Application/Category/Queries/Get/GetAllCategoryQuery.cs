using MediatR;
using News.Domain.Dtos.News;

namespace News.Application.Category.Queries.Get
{
    public class GetAllCategoryQuery : IRequest<List<NewsCategoryDto>>
    {

    }
}
