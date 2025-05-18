using Menus.Domain.Menu.Repositories;

namespace Menus.Domain.UnitOfWork.Menu
{
    public interface IReadUnitOfWork
    {
        IMenuReadRepository MenuReadRepository { get; }
    }
}
