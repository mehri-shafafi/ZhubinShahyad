using Menus.Domain.Menu;
using Menus.Domain.Menu.Repositories;
using Menus.Domain.UnitOfWork.Menu;

namespace Menus.Infrastructure;

public class ReadUnitOfWork : IReadUnitOfWork
{

    private readonly MenuDbContext _context;
    public ReadUnitOfWork(MenuDbContext context)
    {
        _context = context;
    }
    private MenuReadRepository _menuReadRepository;
    public IMenuReadRepository MenuReadRepository
    {
        get
        {
            return _menuReadRepository ??= new MenuReadRepository(_context);
        }
    }

}
