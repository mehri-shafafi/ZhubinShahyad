using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using News.Application.Dtos.News;
using News.Domain.UnitOfWork.News;
using RedisManager;

namespace News.Application.Author.Queries.GetNewsCommentById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, NewsAuthorDto>
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
        public async Task<NewsAuthorDto> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            NewsAuthorDto? resCache = await _cache.GetRecordAsync<NewsAuthorDto>("authorById");

            if (resCache != null)
            {
                return resCache;
            }

            var result = await _readunitOfWork.NewsReadRepository.GetNewsAuthorAsync(request.Id);
            if (result == null)
            {
                throw new System.Exception("author not found");
            }
            var resultModel = _mapper.Map<NewsAuthorDto>(result);
            await _cache.SetRecordAsync(string.Format("authorById"), resultModel, TimeSpan.FromHours(6));
            return resultModel;
        }
    }
}
