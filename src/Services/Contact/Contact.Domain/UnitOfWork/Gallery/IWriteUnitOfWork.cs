using Gallery.Domain.Repositories;

namespace Gallery.Domain.UnitOfWork.Gallery
{
    public interface IWriteUnitOfWork
    {
        IGalleryWriteRepository GalleryWriteRepository { get; }
    }
}
