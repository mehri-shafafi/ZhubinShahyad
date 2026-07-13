using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Products.Application.Dtos.Brands;
using Products.Domain.Products.Models;
using Products.Domain.UnitOfWork.Product;

namespace Products.Application.Products.Commands.Brand.Create;

public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, ProductBrandDto>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateBrandCommandHandler> _logger;


    public CreateBrandCommandHandler(IWriteUnitOfWork writeUnitOfWork, IMapper mapper, ILogger<CreateBrandCommandHandler> logger)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<ProductBrandDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        var BrandModel = _mapper.Map<ProductBrandModel>(request);
        var result = await _writeUnitOfWork.ProductWriteRepository.AddBrandAsync(BrandModel);
        _logger.LogInformation($"Product {result.Id} is successfully created.");

        return _mapper.Map<ProductBrandDto>(result);
    }
}