using AutoMapper;
using MediatR;
using News.Application.Author.Queries.Get;
using News.Domain.Dtos.News;
using News.Domain.News.Repositories;
using News.Domain.UnitOfWork.News;

namespace News.Application.Category.Queries.Get
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<NewsCategoryDto>>
    {


        private readonly IReadUnitOfWork _readUnitOfWork;
        private readonly IMapper _mapper;

        public GetAllCategoryQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper)
        {
            _readUnitOfWork = readUnitOfWork;
            _mapper = mapper;
        }
        public async Task<List<NewsCategoryDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _readUnitOfWork.NewsReadRepository.GetNewsCategoryAllAsync();
            var resultModel = _mapper.Map<List<NewsCategoryDto>>(result);
            return resultModel;
        }
    }
}
