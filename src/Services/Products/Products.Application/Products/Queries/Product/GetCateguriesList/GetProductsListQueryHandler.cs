using AutoMapper;
using MediatR;
using Products.Application.Dtos.Products;
using Products.Domain.UnitOfWork.Product;
namespace Products.Application.Products.Queries.Product.GetCateguriesList
{
    internal class GetProductsListQueryHandler : IRequestHandler<GetCateguriesListQuery, List<ProductCategoryDto>>
    {

        private readonly IReadUnitOfWork _readUnitOfWork;
        private readonly IMapper _mapper;

        public GetProductsListQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper)
        {
            _readUnitOfWork = readUnitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ProductCategoryDto>> Handle(GetCateguriesListQuery request, CancellationToken cancellationToken)
        {
            var productList = await _readUnitOfWork.ProductReadRepository.FetchAllProductCategoryAsync();
            var result = _mapper.Map<List<ProductCategoryDto>>(productList);


            return result;
        }
    }
}
