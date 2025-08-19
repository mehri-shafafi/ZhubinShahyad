using Gallery.Domain.BaseProject.Repositories;
using Gallery.Domain.Menu;
using Gallery.Domain.UnitOfWork.Base;

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
