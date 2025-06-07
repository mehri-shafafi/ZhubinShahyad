using Education.Domain.Education.Dtos;
using Education.Domain.Education.Models;

namespace Education.Domain.Education.Repositories
{
    public interface IEducationReadRepository
    {

        #region
        Task<List<TrainingDto>> GetEducationAllAsync(string language = "fa");
        Task<Training> GetEducationAsync(int id);
        Task<List<TrainingCategoryDto>> GeTrainingCategoriesAllAsync();

        #endregion
    }
}
