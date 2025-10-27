using AutoMapper;
using News.Domain.News.Repositories;
using News.Domain.UnitOfWork.News;
using News.Infrastructure.News;

namespace News.Infrastructure
{
    public class WriteUnitOfWork : IWriteUnitOfWork
    {
        private INewsWriteRepository _newsWriteRepository;
        private readonly NewsDbContext _context;
        private readonly IMapper _mapper;
        public WriteUnitOfWork(NewsDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public INewsWriteRepository NewsWriteRepository
        {
            get
            {
                return _newsWriteRepository ??= new NewsWriteRepository(_context,_mapper);
            }
        }
    }
}
