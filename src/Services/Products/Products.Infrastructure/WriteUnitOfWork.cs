using Products.Domain.Products.Repositories;
using Products.Domain.UnitOfWork.Product;
using Products.Infrastructure.Products;

namespace Products.Infrastructure;

public class WriteUnitOfWork : IWriteUnitOfWork
{
    private IProductWriteRepository _ProductWriteRepository;
    private readonly ProductDbContext _context;
    public WriteUnitOfWork(ProductDbContext context)
    {
        _context = context;
    }
    public IProductWriteRepository ProductWriteRepository
    {
        get
        {
            return _ProductWriteRepository ??= new ProductWriteRepository(_context);
        }
    }
}
