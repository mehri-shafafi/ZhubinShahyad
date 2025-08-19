using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Gallery.Application.Exception;
using Gallery.Domain.UnitOfWork.Base;
namespace Gallery.Application.Gallery.Commands.Base.UpdateGallery;

public class UpdateGalleryCommandHandler : IRequestHandler<UpdateGalleryCommand, bool>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IReadUnitOfWork _readUnitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateGalleryCommandHandler> _logger;

    public UpdateGalleryCommandHandler(IWriteUnitOfWork writeUnitOfWork, IReadUnitOfWork readUnitOfWork, IMapper mapper, ILogger<UpdateGalleryCommandHandler> logger)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _readUnitOfWork = readUnitOfWork;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<bool> Handle(UpdateGalleryCommand request, CancellationToken cancellationToken)
    {
        var product = await _readUnitOfWork.BaseReadRepository.GetAsyncNoTracking(request.Id);
        if (product == null)
        {
            throw new NotFoundException(nameof(Base), request.Id);
        }
        var updatedBase = _mapper.Map<Domain.Gallery.Models.BaseEntity>(request);
        await _writeUnitOfWork.BaseWriteRepository.UpdateBaseAsync(updatedBase);
        _logger.LogInformation($"Base {product.Id} is successfully updated.");
        return true;
    }
}