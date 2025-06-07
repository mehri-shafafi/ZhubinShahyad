using Education.Domain.Education.Dtos;
using Education.Domain.Education.Models;
using Education.Domain.Education.Repositories;
using Education.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Education.Domain.Education
{
    public class EducationReadRepository : IEducationReadRepository
    {
        private readonly EducationDbContext _dbContext;
        public EducationReadRepository(EducationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TrainingDto>> GetEducationAllAsync(string language = "fa")
        {
            var result = await _dbContext.training
                   .Include(t => t.Translations)
                   .Include(t => t.trainingCategory)
                   .Select(t => new TrainingDto
                   {
                       Id = t.Id,
                       Title = t.Translations.FirstOrDefault(tr => tr.Language == language)!.Title,
                       Description = t.Translations.FirstOrDefault(tr => tr.Language == language)!.Description,
                       ThumbnailUrl = t.ThumbnailUrl,
                       CategoryName = t.trainingCategory.Name,
                       Type = t.Type.ToString(), // یا Enum.GetName(typeof(TrainingType), t.Type)
                       PublishDate = t.PublishDate
                   })
                   .ToListAsync();
            return result;
        }

        public Task<Training> GetEducationAsync(int id)
        {
            return _dbContext.training.FirstOrDefaultAsync(P => P.Id == id);
        }


        // Education_Comment






    }
}
