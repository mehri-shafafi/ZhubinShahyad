using Gallery.Domain.Repositories;
using Gallery.Domain.UnitOfWork.Base;
using Gallery.Infrastructure.Gallery;

namespace Gallery.Infrastructure;

public class WriteUnitOfWork : IWriteUnitOfWork
{
    private IGalleryWriteRepository _GalleryWriteRepository;
    private readonly GalleryDbContext _context;
    public WriteUnitOfWork(GalleryDbContext context)
    {
        _context = context;
    }
    public IGalleryWriteRepository GalleryWriteRepository
    {
        get
        {
            return _GalleryWriteRepository ??= new GalleryWriteRepository(_context);
        }
    }
}
