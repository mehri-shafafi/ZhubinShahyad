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
            var result = await _dbContext.Training
         .AsNoTracking()
         .Select(t => new TrainingDto
         {
             TrainingId = t.Id,

             Title = t.Translations
                 .Where(tr => tr.Language == language)
                 .Select(tr => tr.Title)
                 .FirstOrDefault() ?? string.Empty,

             Description = t.Translations
                 .Where(tr => tr.Language == language)
                 .Select(tr => tr.Description)
                 .FirstOrDefault() ?? string.Empty,

             ThumbnailUrl = t.ThumbnailUrl,
             CategoryId = t.CategoryId,
             Type = t.Type.ToString(),
             PublishDate = t.PublishDate
         })
         .ToListAsync();

            return result;
        }

        public Task<Training> GetEducationAsync(int id)
        {
            return _dbContext.Training.FirstOrDefaultAsync(P => P.Id == id);
        }

        public async Task<List<TrainingCategoryDto>> GeTrainingCategoriesAllAsync()
        {
            var result = await _dbContext.TrainingCategories
                   .Select(t => new TrainingCategoryDto
                   {
                       Id = t.Id,
                       Name = t.Name,
                       CreationDateTime = t.CreationDateTime,
                       ModificationDateTime = t.ModificationDateTime,

                   })
                   .ToListAsync();
            return result;
        }
        // Education_Comment






    }
}
