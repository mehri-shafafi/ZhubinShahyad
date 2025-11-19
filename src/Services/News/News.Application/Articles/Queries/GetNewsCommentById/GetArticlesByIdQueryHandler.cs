using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using News.Application.Dtos.News;
using News.Domain.UnitOfWork.News;
using RedisManager;

namespace News.Application.Articles.Queries.GetNewsCommentById
{
    public class GetArticlesByIdQueryHandler : IRequestHandler<GetArticlesByIdQuery, NewsArticleResDto>
    {
        private readonly IMapper _mapper;
        private readonly IReadUnitOfWork _readunitOfWork;
        private readonly IDistributedCache _cache;

        public GetArticlesByIdQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper, IDistributedCache cache)
        {
            _readunitOfWork = readUnitOfWork;
            _mapper = mapper;
            _cache = cache;
        }
        public async Task<NewsArticleResDto> Handle(GetArticlesByIdQuery request, CancellationToken cancellationToken)
        {
            NewsArticleResDto resCache = new NewsArticleResDto();
            resCache = await _cache.GetRecordAsync<NewsArticleResDto>(string.Format("GetArticlesById"));
            if (resCache != null)
            {
                return resCache;
            }

            var result = await _readunitOfWork.NewsReadRepository.GetNewsArticleAsync(request.Id);
            var resultModel = _mapper.Map<NewsArticleResDto>(result);
            await _cache.SetRecordAsync(string.Format("GetArticlesById"), resultModel, TimeSpan.FromHours(6));
            return resultModel;
        }
    }
}
