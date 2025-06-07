using Education.Domain.Education.Models;
using Education.Domain.Education.Repositories;

namespace Education.Infrastructure.Education
{
    public class EducationWriteRepository : IEducationWriteRepository
    {
        private readonly EducationDbContext _dbContext;
        public EducationWriteRepository(EducationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Training> AddEducation_CommentAsync(Training training)
        {
            var result = await _dbContext.AddAsync(training);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Training> UpdateEducation_CommentAsync(Training training)
        {
            var result = _dbContext.Update(training);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteEducation_CommentAsync(int id)
        {
            var comment = await _dbContext.training.FindAsync(id);
            if (comment != null)
            {
                _dbContext.training.Remove(comment);
                await _dbContext.SaveChangesAsync();
            }
        }

    }
}
