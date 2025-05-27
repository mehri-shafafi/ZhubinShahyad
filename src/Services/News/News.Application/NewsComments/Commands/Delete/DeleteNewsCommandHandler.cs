using MediatR;
using Microsoft.Extensions.Logging;
using News.Application.Exception;
using News.Application.NewsCommands.Commands.Delete;
using News.Domain.UnitOfWork.News;


namespace News.Application.News.Commands.News;
public class DeleteArticlesCommandHandler : IRequestHandler<DeleteNewsCommand, bool>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IReadUnitOfWork _readUnitOfWork;

    private readonly ILogger<DeleteArticlesCommandHandler> _logger;

    public DeleteArticlesCommandHandler(IWriteUnitOfWork writeUnitOfWork, IReadUnitOfWork readUnitOfWork, ILogger<DeleteArticlesCommandHandler> logger)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _readUnitOfWork = readUnitOfWork;
        _logger = logger;
    }
    public async Task<bool> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
    {
        var result = await _readUnitOfWork.NewsReadRepository.GetNewsCommentAsync(request.Id);
        if (result == null)
        {
            throw new NotFoundException("result", request.Id);
        }

        await _writeUnitOfWork.NewsWriteRepository.DeleteNews_CommentAsync(result.Id);

        return true;


    }
}

