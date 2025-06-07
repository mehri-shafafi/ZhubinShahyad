using Education.Domain.Education.Repositories;

namespace Education.Domain.UnitOfWork.Education
{
    public interface IWriteUnitOfWork
    {
        IEducationWriteRepository EducationWriteRepository { get; }
    }
}
