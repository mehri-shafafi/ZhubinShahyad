using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using News.Application.Dtos.News;
using News.Domain.UnitOfWork.News;
using RedisManager;

namespace News.Application.Category.Queries.Get
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, NewsCategoryResDto>
    {
        private readonly IMapper _mapper;
        private readonly IReadUnitOfWork _readunitOfWork;
        private readonly IDistributedCache _cache;
        public GetCategoryByIdQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper,IDistributedCache cache)
        {
            _readunitOfWork = readUnitOfWork;
            _mapper = mapper;
            _cache = cache;

        }
        public async Task<NewsCategoryResDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            NewsCategoryResDto? resCache = await _cache.GetRecordAsync<NewsCategoryResDto>("categoryById");

            if (resCache != null)
            {
                return resCache;
            }

            var result = await _readunitOfWork.NewsReadRepository.GetNewsArticleAsync(request.Id);
            if (result == null)
            {
                throw new System.Exception("category not found");
            }
            var resultModel = _mapper.Map<NewsCategoryResDto>(result);
            await _cache.SetRecordAsync(string.Format("categoryById"), resultModel, TimeSpan.FromHours(6));
            return resultModel;
        }
    }
}
