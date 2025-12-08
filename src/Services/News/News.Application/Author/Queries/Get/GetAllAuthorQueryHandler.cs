using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using News.Application.Dtos.News;
using News.Domain.UnitOfWork.News;
using RedisManager;

namespace News.Application.Author.Queries.Get
{
    public class GetAllAuthorQueryHandler : IRequestHandler<GetAllAuthorQuery, List<NewsAuthorDto>>
    {


        private readonly IReadUnitOfWork _readUnitOfWork;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;
        public GetAllAuthorQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper, IDistributedCache cache)
        {
            _readUnitOfWork = readUnitOfWork;
            _mapper = mapper;
            _cache=cache;
        }
        public async Task<List<NewsAuthorDto>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
        {

            List<NewsAuthorDto>? resCache = await _cache.GetRecordAsync<List<NewsAuthorDto>>(string.Format("authores:list"));
            if (resCache != null && resCache.Count > 0)
            {
                return resCache;
            }

            var result = await _readUnitOfWork.NewsReadRepository.GetNewsAuthorAllAsync();
            var resultModel = _mapper.Map<List<NewsAuthorDto>>(result);
            await _cache.SetRecordAsync("authores:list", resultModel, TimeSpan.FromHours(6));
            return resultModel;
        }
    }
}
