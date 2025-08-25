using Gallery.Domain.Menu;
using Gallery.Domain.Repositories;
using Gallery.Domain.UnitOfWork.Gallery;

namespace Gallery.Infrastructure;

public class ReadUnitOfWork : IReadUnitOfWork
{

    private readonly GalleryDbContext _context;
    public ReadUnitOfWork(GalleryDbContext context)
    {
        _context = context;
    }
    private GalleryReadRepository _galleryReadRepository;
    public IGalleryReadRepository GalleryReadRepository
    {
        get
        {
            return _galleryReadRepository ??= new GalleryReadRepository(_context);
        }
    }

}
