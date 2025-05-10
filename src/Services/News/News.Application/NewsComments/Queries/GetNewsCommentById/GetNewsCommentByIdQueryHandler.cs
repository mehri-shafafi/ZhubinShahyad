using AutoMapper;
using MediatR;
using News.Domain.Dtos.News;
using News.Domain.News.Repositories;
using News.Domain.UnitOfWork.News;

namespace News.Application.NewsComments.Queries.GetNewsCommentById
{
    public class GetNewsCommentByIdQueryHandler : IRequestHandler<GetNewsCommentByIdQuery, NewsCommentDto>
    {
        private readonly IMapper _mapper;
        private readonly IReadUnitOfWork _readunitOfWork;
        private readonly INewsReadRepository _newsRepository;
        public GetNewsCommentByIdQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper, INewsReadRepository newsRepository)
        {
            _readunitOfWork = readUnitOfWork;
            _mapper = mapper;
            _newsRepository = newsRepository;

        }
        public async Task<NewsCommentDto> Handle(GetNewsCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _readunitOfWork.NewsReadRepository.GetNewsCommentAsync(request.NewsCommentId);
            var resultModel = _mapper.Map<NewsCommentDto>(result);
            return resultModel;
        }
    }
}
