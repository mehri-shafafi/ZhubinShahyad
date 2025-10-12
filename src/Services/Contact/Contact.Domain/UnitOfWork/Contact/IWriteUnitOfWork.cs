using Contact.Domain.Repositories;

namespace Contact.Domain.UnitOfWork.Contact
{
    public interface IWriteUnitOfWork
    {
        IContactWriteRepository ContactWriteRepository { get; }
    }
}
