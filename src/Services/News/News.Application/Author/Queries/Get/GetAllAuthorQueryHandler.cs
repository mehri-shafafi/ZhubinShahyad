using AutoMapper;
using MediatR;
using News.Application.Author.Queries.Get;
using News.Domain.Dtos.News;
using News.Domain.News.Repositories;
using News.Domain.UnitOfWork.News;

namespace News.Application.Author.Queries.Get
{
    public class GetAllAuthorQueryHandler : IRequestHandler<GetAllAuthorQuery, List<NewsAuthorDto>>
    {


        private readonly IReadUnitOfWork _readUnitOfWork;
        private readonly IMapper _mapper;

        public GetAllAuthorQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper)
        {
            _readUnitOfWork = readUnitOfWork;
            _mapper = mapper;
        }
        public async Task<List<NewsAuthorDto>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
        {
            var result = await _readUnitOfWork.NewsReadRepository.GetNewsAuthorAllAsync();
            var resultModel = _mapper.Map<List<NewsAuthorDto>>(result);
            return resultModel;
        }
    }
}
