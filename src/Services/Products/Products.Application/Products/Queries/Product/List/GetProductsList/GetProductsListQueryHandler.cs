using AutoMapper;
using MediatR;
using Products.Application.Dtos.Products;
using Products.Domain.UnitOfWork.Product;
namespace Products.Application.Products.Queries.Product.List.GetProductsList;

internal class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery,ProductResponseDto<List<ProductDto>>>,
                                            IRequestHandler<GetProductsForClientQuery, ProductResponseDto<List<ProductDetailsDto>>>
{
    private readonly IReadUnitOfWork _readUnitOfWork;
    private readonly IMapper _mapper;

    public GetProductsListQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper)
    {
        _readUnitOfWork = readUnitOfWork;
        _mapper = mapper;
    }
    public async Task<ProductResponseDto<List<ProductDto>>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
    {
        var result = await _readUnitOfWork.ProductReadRepository.FetchAllProductEntityAsync();
        var products = _mapper.Map<List<ProductDto>>(result);

        return new ProductResponseDto<List<ProductDto>>
        {
            IsSuccess = true,
            Message = "Success",
            StatusCode = 200,
            Data = products
        };
    }
    public async Task<ProductResponseDto<List<ProductDetailsDto>>> Handle(GetProductsForClientQuery request, CancellationToken cancellationToken)
    {
        var result = await _readUnitOfWork.ProductReadRepository.FetchAllProductEntityAsync();
        var products = _mapper.Map<List<ProductDetailsDto>>(result);


        return new ProductResponseDto<List<ProductDetailsDto>>
        {
            IsSuccess = true,
            Message = "Success",
            StatusCode = 200,
            Data = products
        };
    }
}
