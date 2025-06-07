using Education.Domain.Education.Dtos;
using MediatR;

namespace Education.Application.EducationComments.Queries.GetEducationCommentById
{
    public class GetEducationByIdQuery : IRequest<TrainingDto>
    {
        public int TrainingId { get; set; }
    }
}
