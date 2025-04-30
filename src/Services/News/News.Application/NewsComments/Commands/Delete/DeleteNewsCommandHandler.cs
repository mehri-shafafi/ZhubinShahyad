using MediatR;
using Microsoft.Extensions.Logging;
using News.Application.NewsCommands.Commands.Delete;
using News.Domain.UnitOfWork.News;
using News.Application.Exception;


namespace News.Application.News.Commands.News;
public class DeleteNewsCommandHandler : IRequestHandler<DeleteNewsCommand, bool>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IReadUnitOfWork _readUnitOfWork;

    private readonly ILogger<DeleteNewsCommandHandler> _logger;

    public DeleteNewsCommandHandler(IWriteUnitOfWork writeUnitOfWork, IReadUnitOfWork readUnitOfWork, ILogger<DeleteNewsCommandHandler> logger)
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

