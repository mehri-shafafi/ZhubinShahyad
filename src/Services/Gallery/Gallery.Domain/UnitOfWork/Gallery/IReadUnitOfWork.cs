using Gallery.Domain.BaseProject.Repositories;

namespace Gallery.Domain.UnitOfWork.Base
{
    public interface IReadUnitOfWork
    {
        IGalleryReadRepository GalleryReadRepository { get; }
    }
}
