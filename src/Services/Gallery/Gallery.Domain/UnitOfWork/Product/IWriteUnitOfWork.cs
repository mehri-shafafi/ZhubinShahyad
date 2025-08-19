using Gallery.Domain.Repositories;

namespace Gallery.Domain.UnitOfWork.Base
{
    public interface IWriteUnitOfWork
    {
        IGalleryWriteRepository GalleryWriteRepository { get; }
    }
}
