using Microsoft.Extensions.Caching.Distributed;
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
        private readonly IDistributedCache _cache;
        public ReadUnitOfWork(NewsDbContext context, IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
        }
        private NewsReadRepository _newsReadRepository;
        public INewsReadRepository NewsReadRepository
        {
            get
            {
                return _newsReadRepository ??= new NewsReadRepository(_context,_cache);
            }
        }

    }

}
