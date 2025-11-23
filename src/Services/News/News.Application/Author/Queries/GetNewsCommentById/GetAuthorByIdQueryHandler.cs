using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using News.Application.Dtos.News;
using News.Domain.UnitOfWork.News;
using RedisManager;

namespace News.Application.Author.Queries.Get
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, NewsAuthorDto>
    {
        private readonly IMapper _mapper;
        private readonly IReadUnitOfWork _readunitOfWork;
        private readonly IDistributedCache _cache;
        public GetCategoryByIdQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper, IDistributedCache cache)
        {
            _readunitOfWork = readUnitOfWork;
            _mapper = mapper;
            _cache = cache;
        }
        public async Task<NewsAuthorDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            NewsAuthorDto? resCache = await _cache.GetRecordAsync<NewsAuthorDto>("GetArticlesById");

            if (resCache != null)
            {
                return resCache;
            }

            var result = await _readunitOfWork.NewsReadRepository.GetNewsArticleAsync(request.Id);
            if (result == null)
            {
                throw new System.Exception("Article not found");
            }
            var resultModel = _mapper.Map<NewsAuthorDto>(result);
            await _cache.SetRecordAsync(string.Format("GetArticlesById"), resultModel, TimeSpan.FromHours(6));
            return resultModel;
        }
    }
}
