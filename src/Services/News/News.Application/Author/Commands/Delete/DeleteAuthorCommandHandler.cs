using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using News.Application.Exception;
using News.Domain.UnitOfWork.News;
using RedisManager;


namespace News.Application.Author.Commands.Delete;
public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, bool>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IReadUnitOfWork _readUnitOfWork;
    private readonly IDistributedCache _cache;
    private readonly ILogger<DeleteAuthorCommandHandler> _logger;

    public DeleteAuthorCommandHandler(IWriteUnitOfWork writeUnitOfWork, IReadUnitOfWork readUnitOfWork, ILogger<DeleteAuthorCommandHandler> logger, IDistributedCache cache)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _readUnitOfWork = readUnitOfWork;
        _logger = logger;
        _cache = cache;
    }
    public async Task<bool> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        var result = await _readUnitOfWork.NewsReadRepository.GetNewsAuthorAsync(request.Id);
        if (result == null)
        {
            throw new NotFoundException("result", request.Id);
        }

        await _writeUnitOfWork.NewsWriteRepository.DeleteNews_AuthorAsync(result);
        await _cache.RemoveRecordAsync(string.Format("authores:list"));
        return true;


    }
}

