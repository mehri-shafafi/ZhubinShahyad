using AutoMapper;
using MediatR;
using Products.Application.Dtos.Products;
using Products.Domain.UnitOfWork.Product;
namespace Products.Application.Products.Queries.Product.ById.GetProductsList;

internal class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductResponseDto<ProductDto>>
{
    private readonly IReadUnitOfWork _readUnitOfWork;
    private readonly IMapper _mapper;

    public GetProductByIdQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper)
    {
        _readUnitOfWork = readUnitOfWork;
        _mapper = mapper;
    }
    public async Task<ProductResponseDto<ProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _readUnitOfWork.ProductReadRepository.FetchProductEntityAsync(request.ProductId);
        var products = _mapper.Map<ProductDto>(result);

        return new ProductResponseDto<ProductDto>
        {
            IsSuccess = true,
            Message = "Success",
            StatusCode = 200,
            Data = products
        };
    }

}
