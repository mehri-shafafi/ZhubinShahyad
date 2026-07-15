using AutoMapper;
using MediatR;
using Products.Application.Dtos.Categories;
using Products.Application.Products.Queries.Product.List.GetCateguriesList;
using Products.Domain.UnitOfWork.Product;
namespace Products.Application.Products.Queries.Product.ById.GetCateguriesList;

internal class GetProductByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
{

    private readonly IReadUnitOfWork _readUnitOfWork;
    private readonly IMapper _mapper;

    public GetProductByIdQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper)
    {
        _readUnitOfWork = readUnitOfWork;
        _mapper = mapper;
    }
    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var productList = await _readUnitOfWork.ProductReadRepository.FetchAllProductCategoryAsync();
        var result = _mapper.Map<CategoryDto>(productList);

        return result;
    }
}
