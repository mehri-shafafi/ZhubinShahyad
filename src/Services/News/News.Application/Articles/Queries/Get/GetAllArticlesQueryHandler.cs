using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using News.Application.Dtos.News;
using News.Domain.UnitOfWork.News;
using RedisManager;

namespace News.Application.Articles.Queries.Get;

public class GetAllArticlesQueryHandler : IRequestHandler<GetAllArticlesQuery, List<NewsArticleResDto>>
{


    private readonly IReadUnitOfWork _readUnitOfWork;
    private readonly IMapper _mapper;
    private readonly IDistributedCache _cache;
    public GetAllArticlesQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper, IDistributedCache cache)
    {
        _readUnitOfWork = readUnitOfWork;
        _mapper = mapper;
        _cache = cache;
    }
    public async Task<List<NewsArticleResDto>> Handle(GetAllArticlesQuery request, CancellationToken cancellationToken)
    {

        List<NewsArticleResDto>? resCache = await _cache.GetRecordAsync<List<NewsArticleResDto>>(string.Format("GetArticles"));
        if (resCache != null && resCache.Count > 0)
        {   
            return resCache;
        }

        var result = await _readUnitOfWork.NewsReadRepository.GetNewsArticleAllAsync();

        var resultModel = _mapper.Map<List<NewsArticleResDto>>(result);
        await _cache.SetRecordAsync("GetArticles", resultModel, TimeSpan.FromHours(6));
        return resultModel;
    }
}
