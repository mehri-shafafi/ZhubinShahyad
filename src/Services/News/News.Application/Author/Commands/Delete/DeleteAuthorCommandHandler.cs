using MediatR;
using Microsoft.Extensions.Logging;
using News.Application.Exception;
using News.Domain.UnitOfWork.News;


namespace News.Application.Author.Commands.Delete;
public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IReadUnitOfWork _readUnitOfWork;

    private readonly ILogger<DeleteCategoryCommandHandler> _logger;

    public DeleteCategoryCommandHandler(IWriteUnitOfWork writeUnitOfWork, IReadUnitOfWork readUnitOfWork, ILogger<DeleteCategoryCommandHandler> logger)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _readUnitOfWork = readUnitOfWork;
        _logger = logger;
    }
    public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var result = await _readUnitOfWork.NewsReadRepository.GetNewsAuthorAsync(request.Id);
        if (result == null)
        {
            throw new NotFoundException("result", request.Id);
        }

        await _writeUnitOfWork.NewsWriteRepository.DeleteNews_AuthorAsync(result);

        return true;


    }
}

