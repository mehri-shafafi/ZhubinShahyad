using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using News.Application.Dtos.News;
using News.Domain.News.Models;
using News.Domain.UnitOfWork.News;
using RedisManager;

namespace News.Application.Author.Commands.Create;

public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, bool>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateAuthorCommandHandler> _logger;
    // private readonly IPublishEndpoint _publishEndPoint;
    private readonly IDistributedCache _cache;

    public CreateAuthorCommandHandler(IWriteUnitOfWork writeUnitOfWork, IMapper mapper, ILogger<CreateAuthorCommandHandler> logger, IDistributedCache cache)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _mapper = mapper;
        _logger = logger;
        _cache = cache;
    }

    public async Task<bool> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        var mappedComment = _mapper.Map<News_AuthorModel>(request);
        var result = await _writeUnitOfWork.NewsWriteRepository.AddNews_AuthorAsync(mappedComment);
        if (result)
        {
            await _cache.RemoveRecordAsync(string.Format("authores:list"));
        }
        return result;
    }
}