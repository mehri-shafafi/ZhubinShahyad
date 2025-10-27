using AutoMapper;
using MediatR;
using News.Application.Dtos.News;
using News.Domain.UnitOfWork.News;

namespace News.Application.Author.Queries.Get
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, NewsAuthorDto>
    {
        private readonly IMapper _mapper;
        private readonly IReadUnitOfWork _readunitOfWork;
        public GetCategoryByIdQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper)
        {
            _readunitOfWork = readUnitOfWork;
            _mapper = mapper;

        }
        public async Task<NewsAuthorDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _readunitOfWork.NewsReadRepository.GetNewsCategoryAsync(request.Id);
            var resultModel = _mapper.Map<NewsAuthorDto>(result);
            return resultModel;
        }
    }
}
