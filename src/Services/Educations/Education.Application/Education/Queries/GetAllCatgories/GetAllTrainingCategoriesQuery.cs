using MediatR;
using Education.Domain.Education.Dtos;

namespace Education.Application.EducationComments.Queries.GetAllCatgories
{
    public class GetAllTrainingCategoriesQuery : IRequest<List<TrainingCategoryDto>>
    {

    }
}
