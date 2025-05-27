using AutoMapper;
using MediatR;
using News.Domain.Dtos.News;
using News.Domain.News.Repositories;
using News.Domain.UnitOfWork.News;

namespace News.Application.NewsComments.Queries.GetAllNewsComments
{
    public class GetAllArticlesQueryHandler : IRequestHandler<GetAllArticlesQuery, List<NewsCommentDto>>
    {


        private readonly IReadUnitOfWork _readUnitOfWork;
        private readonly IMapper _mapper;

        public GetAllArticlesQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper)
        {
            _readUnitOfWork = readUnitOfWork;
            _mapper = mapper;
        }
        public async Task<List<NewsCommentDto>> Handle(GetAllArticlesQuery request, CancellationToken cancellationToken)
        {
            var result = await _readUnitOfWork.NewsReadRepository.GetNewsCommentAllAsync();
            var resultModel = _mapper.Map<List<NewsCommentDto>>(result);
            return resultModel;
        }
    }
}
