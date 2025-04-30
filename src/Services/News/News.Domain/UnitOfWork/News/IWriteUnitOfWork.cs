using News.Domain.News.Repositories;

namespace News.Domain.UnitOfWork.News
{
    public interface IWriteUnitOfWork
    {
        INewsWriteRepository NewsWriteRepository { get; }
    }
}
