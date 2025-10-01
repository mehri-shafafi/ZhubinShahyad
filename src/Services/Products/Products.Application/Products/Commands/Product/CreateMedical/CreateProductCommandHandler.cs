using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Products.Application.Dtos.Products;
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
        var newProduct = _mapper.Map<ProductModel>(request);
        var addedProduct = await _writeUnitOfWork.ProductWriteRepository.AddProductAsync(newProduct);
        _logger.LogInformation($"Product {addedProduct.Id} is successfully created.");

        //await _publishEndPoint.Publish(addProductEvent);
        return _mapper.Map<ProductResDto>(addedProduct);
    }
}