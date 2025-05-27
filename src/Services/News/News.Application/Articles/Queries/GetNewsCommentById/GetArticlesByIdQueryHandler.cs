using AutoMapper;
using MediatR;
using News.Domain.Dtos.News;
using News.Domain.News.Repositories;
using News.Domain.UnitOfWork.News;

namespace News.Application.Articles.Queries.GetNewsCommentById
{
    public class GetArticlesByIdQueryHandler : IRequestHandler<GetArticlesByIdQuery, NewsArticleDto>
    {
        private readonly IMapper _mapper;
        private readonly IReadUnitOfWork _readunitOfWork;
        public GetArticlesByIdQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper)
        {
            _readunitOfWork = readUnitOfWork;
            _mapper = mapper;

        }
        public async Task<NewsArticleDto> Handle(GetArticlesByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _readunitOfWork.NewsReadRepository.GetNewsCommentAsync(request.Id);
            var resultModel = _mapper.Map<NewsArticleDto>(result);
            return resultModel;
        }
    }
}
