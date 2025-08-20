using AutoMapper;
using Gallery.Application.Gallery.Commands.Base.CreateGallery;
using Gallery.Domain.Dtos.Gallery;
using Gallery.Domain.Gallery.Models;
using Gallery.Domain.UnitOfWork.Base;
using MediatR;
using Microsoft.Extensions.Logging;
using EventBus.Messages.Events.Gallery;


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
        var addedBase = await _writeUnitOfWork.GalleryWriteRepository.AddGalleryAsync(newBase);
        _logger.LogInformation($"Base {addedBase.Id} is successfully created.");


        var addBaseEvent = new AddGalleryEvent
        {
            Title_FA = addedBase.Title_FA,
            Title_EN = addedBase.Title_EN,
            Title_AR = addedBase.Title_AR,
            ImageUrl = addedBase.ImageUrl,
            CreationDateTime = addedBase.CreationDateTime,
            ModificationDateTime = addedBase.ModificationDateTime,
            CreationDateTimeShamsi = addedBase.CreationDateTimeShamsi,
            ModificationDateTimeShamsi = addedBase.ModificationDateTimeShamsi
        };
        //await _publishEndPoint.Publish(addBaseEvent);
        return _mapper.Map<GalleryResDto>(addedBase);
    }
}