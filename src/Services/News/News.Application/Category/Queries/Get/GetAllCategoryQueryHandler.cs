using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using News.Application.Dtos.News;
using News.Domain.UnitOfWork.News;
using RedisManager;

namespace News.Application.Category.Queries.Get
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<NewsCategoryResDto>>
    {


        private readonly IReadUnitOfWork _readUnitOfWork;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;

        public GetAllCategoryQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper,IDistributedCache cache)
        {
            _readUnitOfWork = readUnitOfWork;
            _mapper = mapper;
            _cache = cache;
        }
        public async Task<List<NewsCategoryResDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {

            List<NewsCategoryResDto>? resCache = await _cache.GetRecordAsync<List<NewsCategoryResDto>>(string.Format("CategoryNewsies:list"));
            if (resCache != null && resCache.Count > 0)
            {
                return resCache;
            }

            var result = await _readUnitOfWork.NewsReadRepository.GetNewsCategoryAllAsync();
            var resultModel = _mapper.Map<List<NewsCategoryResDto>>(result);
            await _cache.SetRecordAsync("CategoryNewsies:list", resultModel, TimeSpan.FromHours(6));
            return resultModel;


         }
    }
}
