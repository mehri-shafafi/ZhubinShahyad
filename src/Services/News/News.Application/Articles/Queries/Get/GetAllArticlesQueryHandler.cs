using AutoMapper;
using MediatR;
using News.Application.Articles.Queries.Get;
using News.Domain.Dtos.News;
using News.Domain.UnitOfWork.News;

namespace News.Application.Articles.Queries.GetAllNewsComments
{
    public class GetAllArticlesQueryHandler : IRequestHandler<GetAllArticlesQuery, List<NewsArticleDto>>
    {


        private readonly IReadUnitOfWork _readUnitOfWork;
        private readonly IMapper _mapper;

        public GetAllArticlesQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper)
        {
            _readUnitOfWork = readUnitOfWork;
            _mapper = mapper;
        }
        public async Task<List<NewsArticleDto>> Handle(GetAllArticlesQuery request, CancellationToken cancellationToken)
        {
            var result = await _readUnitOfWork.NewsReadRepository.GetNewsArticleAllAsync();
            var resultModel = _mapper.Map<List<NewsArticleDto>>(result);
            return resultModel;
        }
    }
}
