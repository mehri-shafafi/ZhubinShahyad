using Menus.Domain.Menu.Repositories;

namespace Menus.Domain.UnitOfWork.Menu
{
    public interface IWriteUnitOfWork
    {
        IMenuWriteRepository MenuWriteRepository { get; }
    }
}
