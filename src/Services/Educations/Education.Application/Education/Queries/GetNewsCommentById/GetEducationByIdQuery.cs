using Education.Domain.Education.Dtos;
using MediatR;

namespace Education.Application.EducationComments.Queries.GetEducationCommentById
{
    public class GetArticlesByIdQuery : IRequest<TrainingDto>
    {
        public int TrainingId { get; set; }
    }
}
