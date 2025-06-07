using Education.Domain.Education.Dtos;
using Education.Domain.Education.Models;
using MediatR;

namespace Education.Application.EducationCommands.Commands.Create;


public class CreateEducationCommand : TrainingDto, IRequest<TrainingDto>
{
}