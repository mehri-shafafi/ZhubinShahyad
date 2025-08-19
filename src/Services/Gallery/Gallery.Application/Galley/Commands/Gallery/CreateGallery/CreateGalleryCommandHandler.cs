using AutoMapper;
using Gallery.Application.Gallery.Commands.Base.CreateGallery;
using Gallery.Domain.Dtos.Gallery;
using Gallery.Domain.Gallery.Models;
using Gallery.Domain.UnitOfWork.Base;
using MediatR;
using Microsoft.Extensions.Logging;

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
        var addedBase = await _writeUnitOfWork.GalleryWriteRepository.AddBaseAsync(newBase);
        _logger.LogInformation($"Base {addedBase.Id} is successfully created.");


        var addBaseEvent = new AddGalleryEvent
        {
            Name_FA = addedBase.Name_FA,
            Description_FA = addedBase.Description_FA,
            Description_AR = addedBase.Description_AR,
            Description_EN = addedBase.Description_EN,
            Name_EN = addedBase.Name_EN,
            Name_AR = addedBase.Name_AR,
            Price = addedBase.Price,
            BrandId = addedBase.BrandId,
            CategoryId = addedBase.CategoryId,
            StockQuantity = addedBase.StockQuantity,
            SKU = addedBase.SKU,
            ImageURL = addedBase.ImageURL,
            Warranty = addedBase.Warranty,
            Rating = addedBase.Rating,
        };
        //await _publishEndPoint.Publish(addBaseEvent);
        return _mapper.Map<BaseResDto>(addedBase);
    }
}