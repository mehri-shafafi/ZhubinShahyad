using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Products.Application.Exception;
using Products.Domain.Products.Models;
using Products.Domain.UnitOfWork.Product;
namespace Products.Application.Products.Commands.Product.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IReadUnitOfWork _readUnitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateProductCommandHandler> _logger;

    public UpdateProductCommandHandler(IWriteUnitOfWork writeUnitOfWork, IReadUnitOfWork readUnitOfWork, IMapper mapper, ILogger<UpdateProductCommandHandler> logger)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _readUnitOfWork = readUnitOfWork;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _readUnitOfWork.ProductReadRepository.GetAsyncNoTracking(request.ProductId);
        if (product == null)
        {
            throw new NotFoundException(nameof(Product), request.ProductId);
        }
        var updatedProduct = _mapper.Map<UpdateProductModel>(request);
        await _writeUnitOfWork.ProductWriteRepository.UpdateProductAsync(updatedProduct);
        _logger.LogInformation($"Product {product.Id} is successfully updated.");
        return true;
    }
}