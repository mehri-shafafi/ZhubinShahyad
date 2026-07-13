using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Products.Application.Exception;
using Products.Application.Products.Commands.Product.DeleteMedical;
using Products.Domain.Products.Models;
using Products.Domain.UnitOfWork.Product;

namespace Products.Application.Products.Commands.Product.DeleteProductImage;


public class DeleteProductImageCommandHandler : IRequestHandler<DeleteProductImageCommand, bool>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IReadUnitOfWork _readUnitOfWork;
    private readonly IMapper _mapper;

    private readonly ILogger<DeleteProductImageCommandHandler> _logger;

    public DeleteProductImageCommandHandler(IWriteUnitOfWork writeUnitOfWork, IReadUnitOfWork readUnitOfWork, ILogger<DeleteProductImageCommandHandler> logger, IMapper mapper)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _readUnitOfWork = readUnitOfWork;
        _logger = logger;
        _mapper = mapper;
    }
    public async Task<bool> Handle(DeleteProductImageCommand request, CancellationToken cancellationToken)
    {
        var productImage = await _readUnitOfWork.ProductReadRepository.GetProductImageByIdAsync(request.Id);
        if (productImage == null)
        {
            throw new NotFoundException("Product", request.Id);
        }
        var productImageToDelete = _mapper.Map<UpdateProductImageModel>(request);

        await _writeUnitOfWork.ProductWriteRepository.DeleteProductImageAsync(productImageToDelete);

        return true;


    }
}

