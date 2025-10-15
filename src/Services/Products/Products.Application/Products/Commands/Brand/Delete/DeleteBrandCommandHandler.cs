using MediatR;
using Microsoft.Extensions.Logging;
using Products.Application.Exception;
using Products.Domain.UnitOfWork.Product;

namespace Products.Application.Products.Commands.Categories.Delete;


public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, bool>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IReadUnitOfWork _readUnitOfWork;

    private readonly ILogger<DeleteBrandCommandHandler> _logger;

    public DeleteBrandCommandHandler(IWriteUnitOfWork writeUnitOfWork, IReadUnitOfWork readUnitOfWork, ILogger<DeleteBrandCommandHandler> logger)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _readUnitOfWork = readUnitOfWork;
        _logger = logger;
    }
    public async Task<bool> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
    {
        var product = await _readUnitOfWork.ProductReadRepository.FetchProductBrandAsync(request.Id);
        if (product == null)
        {
            throw new NotFoundException("Product", request.Id);
        }

        await _writeUnitOfWork.ProductWriteRepository.DeleteBrandAsync(product);

        return true;


    }
}

