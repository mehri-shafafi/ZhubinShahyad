using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Domain.Education.Dtos;
using Education.Domain.Education.Models;

namespace Education.Domain.Education.Repositories
{
    public interface IEducationWriteRepository
    {
        
        #region
        Task<Training> AddEducation_CommentAsync(Training training);
        Task<Training> UpdateEducation_CommentAsync(Training training);
        Task DeleteEducation_CommentAsync(int Id);
        #endregion
    }
}
