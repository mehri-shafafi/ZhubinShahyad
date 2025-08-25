using Gallery.Domain.Repositories;

namespace Gallery.Domain.UnitOfWork.Gallery
{
    public interface IReadUnitOfWork
    {
        IGalleryReadRepository GalleryReadRepository { get; }
    }
}
