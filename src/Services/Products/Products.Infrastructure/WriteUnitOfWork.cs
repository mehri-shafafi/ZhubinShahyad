using AutoMapper;
using Products.Domain.Products.Repositories;
using Products.Domain.UnitOfWork.Product;
using Products.Infrastructure.Products;

namespace Products.Infrastructure;

public class WriteUnitOfWork : IWriteUnitOfWork
{
    private IProductWriteRepository _ProductWriteRepository;
    private readonly ProductDbContext _context;
    private readonly IMapper _mapper;
    public WriteUnitOfWork(ProductDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public IProductWriteRepository ProductWriteRepository
    {
        get
        {
            return _ProductWriteRepository ??= new ProductWriteRepository(_context,_mapper);
        }
    }
}
