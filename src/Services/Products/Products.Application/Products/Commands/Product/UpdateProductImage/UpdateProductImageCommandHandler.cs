using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Products.Application.Exception;
using Products.Domain.Products.Models;
using Products.Domain.UnitOfWork.Product;
namespace Products.Application.Products.Commands.Product.UpdateProductImage;

public class UpdateProductImageCommandHandler : IRequestHandler<UpdateProductImageCommand, bool>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IReadUnitOfWork _readUnitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateProductImageCommandHandler> _logger;

    public UpdateProductImageCommandHandler(IWriteUnitOfWork writeUnitOfWork, IReadUnitOfWork readUnitOfWork, IMapper mapper, ILogger<UpdateProductImageCommandHandler> logger)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _readUnitOfWork = readUnitOfWork;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<bool> Handle(UpdateProductImageCommand request, CancellationToken cancellationToken)
    {
        var productImage = await _readUnitOfWork.ProductReadRepository.GetProductImageByIdAsync(request.Id);
        if (productImage == null)
        {
            throw new NotFoundException(nameof(Product), request.Id);
        }
        var productImageToUpdate = _mapper.Map<UpdateProductImageModel>(request);
        await _writeUnitOfWork.ProductWriteRepository.UpdateProductImageAsync(productImageToUpdate);
        _logger.LogInformation($"Product {productImage.Id} is successfully updated.");
        return true;
    }
}