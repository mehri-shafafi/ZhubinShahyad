using AutoMapper;
using MediatR;
using Products.Application.Dtos.Categories;
using Products.Domain.UnitOfWork.Product;
namespace Products.Application.Products.Queries.Product.List.GetCateguriesList;

internal class GetProductsListQueryHandler : IRequestHandler<GetCategoriesQuery, List<CategoryDto>>
{

    private readonly IReadUnitOfWork _readUnitOfWork;
    private readonly IMapper _mapper;

    public GetProductsListQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper)
    {
        _readUnitOfWork = readUnitOfWork;
        _mapper = mapper;
    }
    public async Task<List<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var productList = await _readUnitOfWork.ProductReadRepository.FetchAllProductCategoryAsync();
        var result = _mapper.Map<List<CategoryDto>>(productList);

        return result;
    }
}
