using MediatR;
using Microsoft.Extensions.Logging;
using Products.Application.Exception;
using Products.Domain.UnitOfWork.Product;

namespace Products.Application.Products.Commands.Categories.Delete;


public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IReadUnitOfWork _readUnitOfWork;

    private readonly ILogger<DeleteCategoryCommandHandler> _logger;

    public DeleteCategoryCommandHandler(IWriteUnitOfWork writeUnitOfWork, IReadUnitOfWork readUnitOfWork, ILogger<DeleteCategoryCommandHandler> logger)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _readUnitOfWork = readUnitOfWork;
        _logger = logger;
    }
    public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var product = await _readUnitOfWork.ProductReadRepository.FetchProductCategoryAsync(request.Id);
        if (product == null)
        {
            throw new NotFoundException("Product", request.Id);
        }

        await _writeUnitOfWork.ProductWriteRepository.DeleteProductCategoriesAsync(product);

        return true;


    }
}

