using AutoMapper;
using MediatR;
using Products.Domain.Base;
using Products.Domain.Dtos.Products;
using Products.Domain.UnitOfWork.Product;
namespace Products.Application.Products.Queries.Product.GetProductsList
{
    internal class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, List<ProductResDto>>
    {

        private readonly IReadUnitOfWork _readUnitOfWork;
        private readonly IMapper _mapper;

        public GetProductsListQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper)
        {
            _readUnitOfWork = readUnitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ProductResDto>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            var result = await _readUnitOfWork.ProductReadRepository.FetchAllProductEntityAsync();
   

            var resultDto= _mapper.Map<List<ProductResDto>>(result);
            return resultDto;
        }
    }
}
