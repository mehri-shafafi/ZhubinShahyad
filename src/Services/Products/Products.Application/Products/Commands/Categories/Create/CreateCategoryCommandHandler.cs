using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Products.Domain.Dtos.Products;
using Products.Domain.Products.Models;
using Products.Domain.UnitOfWork.Product;

namespace Products.Application.Products.Commands.Categories.Create;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ProductCategoryDto>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateCategoryCommandHandler> _logger;
    private readonly IPublishEndpoint _publishEndPoint;


    public CreateCategoryCommandHandler(IWriteUnitOfWork writeUnitOfWork, IMapper mapper, IPublishEndpoint publishEndpoint, ILogger<CreateCategoryCommandHandler> logger)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _mapper = mapper;
        _logger = logger;
        _publishEndPoint = publishEndpoint;
    }

    public async Task<ProductCategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var newProduct = _mapper.Map<ProductCategory>(request);
        var addedProduct = await _writeUnitOfWork.ProductWriteRepository.AddProductCategoriesAsync(newProduct);
        _logger.LogInformation($"Product {addedProduct.Id} is successfully created.");


        var addProductEvent = new AddCateguryProductEvent
        {
            Name_FA = addedProduct.Name_FA,
            Name_EN = addedProduct.Name_EN,
            Name_AR = addedProduct.Name_AR,
            Description = addedProduct.Description,
            Permalink = addedProduct.Permalink,
            Active = addedProduct.Active,
            Priority = addedProduct.Priority,
            BannerUrl = addedProduct.BannerUrl,
            IconUrl = addedProduct.IconUrl,
            ThumbnailUrl = addedProduct.ThumbnailUrl
        };
        await _publishEndPoint.Publish(addProductEvent);
        return _mapper.Map<ProductCategoryDto>(addedProduct);
    }
}