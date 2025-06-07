using MediatR;
using Education.Domain.Education.Dtos;

namespace Education.Application.EducationComments.Queries.GetAllEducationComments
{
    public class GetAllTrainingQuery : IRequest<List<TrainingDto>>
    {
        public string Language { get; set; } = "fa";

    }
}
