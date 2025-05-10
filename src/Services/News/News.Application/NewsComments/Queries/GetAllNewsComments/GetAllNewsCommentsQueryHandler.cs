using AutoMapper;
using MediatR;
using News.Domain.Dtos.News;
using News.Domain.News.Repositories;
using News.Domain.UnitOfWork.News;

namespace News.Application.NewsComments.Queries.GetAllNewsComments
{
    public class GetAllNewsCommentsQueryHandler : IRequestHandler<GetAllNewsCommentsQuery, List<NewsCommentDto>>
    {

        private readonly INewsReadRepository _newsReadRepository  ;
        private readonly IReadUnitOfWork _readUnitOfWork;
        private readonly IMapper _mapper;

        public GetAllNewsCommentsQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper,INewsReadRepository newsReadRepository)
        {
            _readUnitOfWork = readUnitOfWork;
            _newsReadRepository = newsReadRepository;
            _mapper = mapper;
        }
        public async Task<List<NewsCommentDto>> Handle(GetAllNewsCommentsQuery request, CancellationToken cancellationToken)
        {
            var result = await _readUnitOfWork.NewsReadRepository.GetNewsCommentAllAsync();
            var resultModel = _mapper.Map<List<NewsCommentDto>>(result);
            return resultModel;
        }
    }
}
