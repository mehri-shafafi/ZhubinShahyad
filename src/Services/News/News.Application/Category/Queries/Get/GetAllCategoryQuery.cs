using MediatR;
using News.Application.Dtos.News;

namespace News.Application.Category.Queries.Get
{
    public class GetAllCategoryQuery : IRequest<List<NewsCategoryResDto>>
    {

    }
}
