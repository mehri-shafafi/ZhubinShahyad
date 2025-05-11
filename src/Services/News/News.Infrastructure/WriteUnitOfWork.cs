using News.Domain.News.Repositories;
using News.Domain.UnitOfWork.News;
using News.Infrastructure.News;

namespace News.Infrastructure
{
    public class WriteUnitOfWork : IWriteUnitOfWork
    {
        private INewsWriteRepository _newsWriteRepository;
        private readonly NewsDbContext _context;
        public WriteUnitOfWork(NewsDbContext context)
        {
            _context = context;
        }
        public INewsWriteRepository NewsWriteRepository
        {
            get
            {
                return _newsWriteRepository ??= new NewsWriteRepository(_context);
            }
        }
    }
}
