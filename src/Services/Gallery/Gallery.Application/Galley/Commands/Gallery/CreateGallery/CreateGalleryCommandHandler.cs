using AutoMapper;
using Gallery.Application.Gallery.Commands.Base.CreateGallery;
using Gallery.Domain.Dtos.Gallery;
using Gallery.Domain.Gallery.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using EventBus.Messages.Events.Gallery;
using Gallery.Domain.UnitOfWork.Gallery;


namespace Gallery.Application.Gallery.Commands.Base.CreateMedical;

public class CreateBaseCommandHandler : IRequestHandler<CreateGalleryCommand, GalleryResDto>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateBaseCommandHandler> _logger;


    public CreateBaseCommandHandler(IWriteUnitOfWork writeUnitOfWork, IMapper mapper, ILogger<CreateBaseCommandHandler> logger)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GalleryResDto> Handle(CreateGalleryCommand request, CancellationToken cancellationToken)
    {
        var newBase = _mapper.Map<GalleryEntity>(request);
        var result = await _writeUnitOfWork.GalleryWriteRepository.AddGalleryAsync(newBase);
        _logger.LogInformation($"Base {result.Id} is successfully created.");

        return _mapper.Map<GalleryResDto>(result);
    }
}