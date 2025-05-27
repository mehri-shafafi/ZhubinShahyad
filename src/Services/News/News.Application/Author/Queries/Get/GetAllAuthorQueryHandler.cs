using AutoMapper;
using MediatR;
using News.Application.Author.Queries.Get;
using News.Domain.Dtos.News;
using News.Domain.News.Repositories;
using News.Domain.UnitOfWork.News;

namespace News.Application.Author.Queries.Get
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<NewsAuthorDto>>
    {


        private readonly IReadUnitOfWork _readUnitOfWork;
        private readonly IMapper _mapper;

        public GetAllCategoryQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper)
        {
            _readUnitOfWork = readUnitOfWork;
            _mapper = mapper;
        }
        public async Task<List<NewsAuthorDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _readUnitOfWork.NewsReadRepository.GetNewsCommentAllAsync();
            var resultModel = _mapper.Map<List<NewsAuthorDto>>(result);
            return resultModel;
        }
    }
}
