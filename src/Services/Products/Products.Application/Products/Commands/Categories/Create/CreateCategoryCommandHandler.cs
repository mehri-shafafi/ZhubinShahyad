using AutoMapper;
using EventBus.Messages.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using Products.Application.Dtos.Products;
using Products.Domain.Products.Models;
using Products.Domain.UnitOfWork.Product;

namespace Products.Application.Products.Commands.Categories.Create;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ProductCategoryDto>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateCategoryCommandHandler> _logger;


    public CreateCategoryCommandHandler(IWriteUnitOfWork writeUnitOfWork, IMapper mapper, ILogger<CreateCategoryCommandHandler> logger)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<ProductCategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var newProduct = _mapper.Map<ProductCategoryModel>(request);
        var addedProduct = await _writeUnitOfWork.ProductWriteRepository.AddProductCategoriesAsync(newProduct);
        _logger.LogInformation($"Product {addedProduct.Id} is successfully created.");


 
       // await _publishEndPoint.Publish(addProductEvent);
        return _mapper.Map<ProductCategoryDto>(addedProduct);
    }
}