using Education.Domain.Education;
using Education.Domain.Education.Repositories;
using Education.Domain.UnitOfWork.Education;

namespace Education.Infrastructure
{
    public class ReadUnitOfWork : IReadUnitOfWork
    {

        private readonly EducationDbContext _context;
        public ReadUnitOfWork(EducationDbContext context)
        {
            _context = context;
        }
        private EducationReadRepository _EducationReadRepository;
        public IEducationReadRepository EducationReadRepository
        {
            get
            {
                return _EducationReadRepository ??= new EducationReadRepository(_context);
            }
        }

    }

}
