using MediatR;

namespace Education.Application.EducationCommands.Commands.Delete;
public class DeleteEducationCommand : IRequest<bool>
{
    public int Id { get; set; }
}