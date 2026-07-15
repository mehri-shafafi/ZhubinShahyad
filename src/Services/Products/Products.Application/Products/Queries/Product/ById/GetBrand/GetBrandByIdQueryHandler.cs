using AutoMapper;
using MediatR;
using Products.Application.Dtos.Brands;
using Products.Domain.UnitOfWork.Product;
namespace Products.Application.Products.Queries.Product.ById.GetBrand;

internal class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, BrandDto>
{

    private readonly IReadUnitOfWork _readUnitOfWork;
    private readonly IMapper _mapper;

    public GetBrandByIdQueryHandler(IReadUnitOfWork readUnitOfWork, IMapper mapper)
    {
        _readUnitOfWork = readUnitOfWork;
        _mapper = mapper;
    }
    public async Task<BrandDto> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _readUnitOfWork.ProductReadRepository.FetchProductBrandAsync(request.BrandId);
        var resultDto = _mapper.Map<BrandDto>(result);

        return resultDto;
    }
}
