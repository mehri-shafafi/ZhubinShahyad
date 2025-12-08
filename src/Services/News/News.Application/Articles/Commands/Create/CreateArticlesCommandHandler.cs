using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using News.Application.Dtos.News;
using News.Domain.News.Models;
using News.Domain.UnitOfWork.News;
using RedisManager;

namespace News.Application.Articles.Commands.Create;

public class CreateArticlesCommanddHandler : IRequestHandler<CreateArticlesCommand, bool>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateArticlesCommanddHandler> _logger;
    private readonly IDistributedCache _cache;

    public CreateArticlesCommanddHandler(IWriteUnitOfWork writeUnitOfWork, IMapper mapper, ILogger<CreateArticlesCommanddHandler> logger, IDistributedCache cache)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _mapper = mapper;
        _logger = logger;
        _cache = cache;
    }

    public async Task<bool> Handle(CreateArticlesCommand request, CancellationToken cancellationToken)
    {
        var mappedComment = _mapper.Map<News_ArticleModel>(request);
        var result = await _writeUnitOfWork.NewsWriteRepository.AddNews_ArticleAsync(mappedComment);
        await _cache.RemoveRecordAsync(string.Format("GetArticlesById"));

        return result;
    }
}