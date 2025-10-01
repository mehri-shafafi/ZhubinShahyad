using Menus.Domain.Menu.Repositories;
using Menus.Domain.UnitOfWork.Menu;
using Menus.Infrastructure.Menu;

namespace Menus.Infrastructure;

public class WriteUnitOfWork : IWriteUnitOfWork
{
    private IMenuWriteRepository _MenuWriteRepository;
    private readonly MenuDbContext _context;
    public WriteUnitOfWork(MenuDbContext context)
    {
        _context = context;
    }
    public IMenuWriteRepository MenuWriteRepository
    {
        get
        {
            return _MenuWriteRepository ??= new MenuWriteRepository(_context);
        }
    }
}
