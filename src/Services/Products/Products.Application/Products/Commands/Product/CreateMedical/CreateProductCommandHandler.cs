using AutoMapper;
using EventBus.Messages.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using Products.Domain.Dtos.Products;
using Products.Domain.Products.Models;
using Products.Domain.UnitOfWork.Product;

namespace Products.Application.Products.Commands.Product.CreateMedical;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductResDto>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateProductCommandHandler> _logger;


    public CreateProductCommandHandler(IWriteUnitOfWork writeUnitOfWork, IMapper mapper, ILogger<CreateProductCommandHandler> logger)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<ProductResDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var newProduct = _mapper.Map<ProductEntity>(request);
        var addedProduct = await _writeUnitOfWork.ProductWriteRepository.AddProductAsync(newProduct);
        _logger.LogInformation($"Product {addedProduct.Id} is successfully created.");


        var addProductEvent = new AddProductEvent
        {
            Name_FA = addedProduct.Name_FA,
            Description_FA = addedProduct.Description_FA,
            Description_AR = addedProduct.Description_AR,
            Description_EN = addedProduct.Description_EN,
            Name_EN = addedProduct.Name_EN,
            Name_AR = addedProduct.Name_AR,
            Price = addedProduct.Price,
            BrandId = addedProduct.BrandId,
            CategoryId = addedProduct.CategoryId,
            StockQuantity = addedProduct.StockQuantity,
            SKU = addedProduct.SKU,
            Warranty = addedProduct.Warranty,
            Rating = addedProduct.Rating,
        };
        //await _publishEndPoint.Publish(addProductEvent);
        return _mapper.Map<ProductResDto>(addedProduct);
    }
}