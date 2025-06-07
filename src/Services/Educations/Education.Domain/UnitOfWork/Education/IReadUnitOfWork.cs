using Education.Domain.Education.Repositories;

namespace Education.Domain.UnitOfWork.Education
{
    public interface IReadUnitOfWork
    {
        IEducationReadRepository EducationReadRepository { get; }
    }
}
