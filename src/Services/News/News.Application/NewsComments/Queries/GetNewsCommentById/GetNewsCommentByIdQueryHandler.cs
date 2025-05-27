using AutoMapper;
using MediatR;
using News.Domain.Dtos.News;
using News.Domain.News.Repositories;
using News.Domain.UnitOfWork.News;

namespace News.Application.NewsComments.Queries.GetNewsCommentById
{
    public class GetArticlesByIdQueryHandler : IRequestHandler<GetArticlesByIdQuery, NewsCommentDto>
    {
        private readonly IMapper _mapper;
        private readonly IReadUnitOfWork _readunitOfWork;
        public GetArticlesByIdQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper)
        {
            _readunitOfWork = readUnitOfWork;
            _mapper = mapper;

        }
        public async Task<NewsCommentDto> Handle(GetArticlesByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _readunitOfWork.NewsReadRepository.GetNewsCommentAsync(request.NewsCommentId);
            var resultModel = _mapper.Map<NewsCommentDto>(result);
            return resultModel;
        }
    }
}
