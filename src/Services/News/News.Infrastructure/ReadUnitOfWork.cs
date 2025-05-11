using News.Domain.News;
using News.Domain.News.Repositories;
using News.Domain.UnitOfWork.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Infrastructure
{
    public class ReadUnitOfWork : IReadUnitOfWork
    {

        private readonly NewsDbContext _context;
        public ReadUnitOfWork(NewsDbContext context)
        {
            _context = context;
        }
        private NewsReadRepository _newsReadRepository;
        public INewsReadRepository NewsReadRepository
        {
            get
            {
                return _newsReadRepository ??= new NewsReadRepository(_context);
            }
        }

    }

}
