using News.Domain.News.Repositories;

namespace News.Domain.UnitOfWork.News
{
    public interface IReadUnitOfWork
    {
        INewsReadRepository NewsReadRepository { get; }
    }
}
