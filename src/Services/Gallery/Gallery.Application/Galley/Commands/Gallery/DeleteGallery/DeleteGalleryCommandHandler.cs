using Gallery.Application.Exception;
using Gallery.Domain.UnitOfWork.Base;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Gallery.Application.Gallery.Commands.Base.DeleteGallery;


public class DeleteGalleryCommandHandler : IRequestHandler<DeleteGalleryCommand, bool>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IReadUnitOfWork _readUnitOfWork;

    private readonly ILogger<DeleteGalleryCommandHandler> _logger;

    public DeleteGalleryCommandHandler(IWriteUnitOfWork writeUnitOfWork, IReadUnitOfWork readUnitOfWork, ILogger<DeleteGalleryCommandHandler> logger)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _readUnitOfWork = readUnitOfWork;
        _logger = logger;
    }
    public async Task<bool> Handle(DeleteGalleryCommand request, CancellationToken cancellationToken)
    {
        var product = await _readUnitOfWork.GalleryReadRepository.FetchGalleryEntityAsync(request.Id);
        if (product == null)
        {
            throw new NotFoundException("Base", request.Id);
        }

        await _writeUnitOfWork.GalleryWriteRepository.DeleteBrandAsync(product);

        return true;


    }
}

