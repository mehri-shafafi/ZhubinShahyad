using Education.Domain.Education.Repositories;
using Education.Domain.UnitOfWork.Education;
using Education.Infrastructure.Education;

namespace Education.Infrastructure
{
    public class WriteUnitOfWork : IWriteUnitOfWork
    {
        private IEducationWriteRepository _EducationWriteRepository;
        private readonly EducationDbContext _context;
        public WriteUnitOfWork(EducationDbContext context)
        {
            _context = context;
        }
        public IEducationWriteRepository EducationWriteRepository
        {
            get
            {
                return _EducationWriteRepository ??= new EducationWriteRepository(_context);
            }
        }
    }
}
