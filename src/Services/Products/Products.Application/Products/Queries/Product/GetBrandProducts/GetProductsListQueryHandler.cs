using AutoMapper;
using MediatR;
using Products.Application.Dtos.Products;
using Products.Domain.UnitOfWork.Product;
namespace Products.Application.Products.Queries.Product.GetBrandProducts
{
    internal class GetBrandProductsListQueryHandler : IRequestHandler<GetBrandProductsListQuery, List<ProductBrandDto>>
    {

        private readonly IReadUnitOfWork _readUnitOfWork;
        private readonly IMapper _mapper;

        public GetBrandProductsListQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper)
        {
            _readUnitOfWork = readUnitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ProductBrandDto>> Handle(GetBrandProductsListQuery request, CancellationToken cancellationToken)
        {
            var result = await _readUnitOfWork.ProductReadRepository.FetchAllProductBrandAsync();
            var resultDto = _mapper.Map<List<ProductBrandDto>>(result);

            return resultDto;
        }
    }
}
