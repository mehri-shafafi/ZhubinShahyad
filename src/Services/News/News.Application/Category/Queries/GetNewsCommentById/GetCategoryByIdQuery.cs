using MediatR;
using News.Application.Dtos.News;

namespace News.Application.Category.Queries.Get
{
    public class GetCategoryByIdQuery : IRequest<NewsCategoryDto>
    {
        public int Id { get; set; }
    }
}
