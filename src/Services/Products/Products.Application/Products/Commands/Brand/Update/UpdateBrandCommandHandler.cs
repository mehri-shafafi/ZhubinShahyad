using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Products.Application.Exception;
using Products.Domain.UnitOfWork.Product;
using Products.Domain.Products.Models;
using Microsoft.EntityFrameworkCore;

namespace Products.Application.Products.Commands.Categories.Update;

public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, bool>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IReadUnitOfWork _readUnitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateBrandCommandHandler> _logger;

    public UpdateBrandCommandHandler(IWriteUnitOfWork writeUnitOfWork, IReadUnitOfWork readUnitOfWork, IMapper mapper, ILogger<UpdateBrandCommandHandler> logger)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _readUnitOfWork = readUnitOfWork;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<bool> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
    {
        var existingBrand = await _readUnitOfWork.ProductReadRepository.FetchProductBrandAsync(request.Id);
        if (existingBrand == null)
        {
            throw new NotFoundException(nameof(Product), request.Id);
        }
      
        var result = _mapper.Map<ProductBrandModel>(request);
        await _writeUnitOfWork.ProductWriteRepository.UpdateBrandAsync(result);
        _logger.LogInformation($"Product {result.Id} is successfully updated.");
        return true;
    }
}



