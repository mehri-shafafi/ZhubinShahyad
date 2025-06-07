using MediatR;
using Education.Domain.Education.Dtos;

namespace Education.Application.Education.Commands.Education.Update;

public class UpdateEducationCommand : TrainingDto, IRequest<bool>
{
    public int TraininId { get; set; }
}