using AutoMapper;
using MediatR;
using News.Domain.Dtos.News;
using News.Domain.News.Repositories;
using News.Domain.UnitOfWork.News;

namespace News.Application.Articles.Queries.GetNewsCommentById
{
    public class GetArticlesByIdQueryHandler : IRequestHandler<GetArticlesByIdQuery, NewsArticleResDto>
    {
        private readonly IMapper _mapper;
        private readonly IReadUnitOfWork _readunitOfWork;
        public GetArticlesByIdQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper)
        {
            _readunitOfWork = readUnitOfWork;
            _mapper = mapper;

        }
        public async Task<NewsArticleResDto> Handle(GetArticlesByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _readunitOfWork.NewsReadRepository.GetNewsArticleAsync(request.Id);
            var resultModel = _mapper.Map<NewsArticleResDto>(result);
            return resultModel;
        }
    }
}
