using MediatR;
using News.Application.Dtos.News;

namespace News.Application.Category.Queries.Get
{
    public class GetCategoryByIdQuery : IRequest<NewsCategoryResDto>
    {
        public int Id { get; set; }
    }
}
