using MediatR;
using Microsoft.Extensions.Logging;
using Education.Application.Exception;
using Education.Application.EducationCommands.Commands.Delete;
using Education.Domain.UnitOfWork.Education;


namespace Education.Application.Education.Commands.Education;
public class DeleteArticlesCommandHandler : IRequestHandler<DeleteEducationCommand, bool>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IReadUnitOfWork _readUnitOfWork;

    private readonly ILogger<DeleteArticlesCommandHandler> _logger;

    public DeleteArticlesCommandHandler(IWriteUnitOfWork writeUnitOfWork, IReadUnitOfWork readUnitOfWork, ILogger<DeleteArticlesCommandHandler> logger)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _readUnitOfWork = readUnitOfWork;
        _logger = logger;
    }
    public async Task<bool> Handle(DeleteEducationCommand request, CancellationToken cancellationToken)
    {
        var result = await _readUnitOfWork.EducationReadRepository.GetEducationAsync(request.Id);
        if (result == null)
        {
            throw new NotFoundException("result", request.Id);
        }

        await _writeUnitOfWork.EducationWriteRepository.DeleteEducation_CommentAsync(result.Id);

        return true;


    }
}

