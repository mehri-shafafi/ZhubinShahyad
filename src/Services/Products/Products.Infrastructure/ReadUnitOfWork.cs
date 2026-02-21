using Products.Domain.Products.Repositories;
using Products.Domain.UnitOfWork.Product;
using Products.Infrastructure.Products;

namespace Products.Infrastructure;

public class ReadUnitOfWork : IReadUnitOfWork
{

    private readonly ProductDbContext _context;
    public ReadUnitOfWork(ProductDbContext context)
    {
        _context = context;
    }
    private ProductReadRepository _productReadRepository;
    public IProductReadRepository ProductReadRepository
    {
        get
        {
            return _productReadRepository ??= new ProductReadRepository(_context);
        }
    }

}
