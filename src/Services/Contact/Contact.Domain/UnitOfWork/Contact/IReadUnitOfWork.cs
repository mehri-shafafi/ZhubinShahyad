using Contact.Domain.Repositories;

namespace Contact.Domain.UnitOfWork.Contact
{
    public interface IReadUnitOfWork
    {
        IContactReadRepository ContactReadRepository { get; }
    }
}

