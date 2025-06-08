using AutoMapper;
using MediatR;
using News.Domain.Dtos.News;
using News.Domain.UnitOfWork.News;

namespace News.Application.Category.Queries.Get
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, NewsCategoryDto>
    {
        private readonly IMapper _mapper;
        private readonly IReadUnitOfWork _readunitOfWork;
        public GetCategoryByIdQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper)
        {
            _readunitOfWork = readUnitOfWork;
            _mapper = mapper;

        }
        public async Task<NewsCategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _readunitOfWork.NewsReadRepository.GetNewsCategoryAsync(request.Id);
            var resultModel = _mapper.Map<NewsCategoryDto>(result);
            return resultModel;
        }
    }
}
