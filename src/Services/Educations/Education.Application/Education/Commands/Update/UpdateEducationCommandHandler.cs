using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Education.Application.Exception;
using Education.Application.Education.Commands.Education.Update;
using Education.Domain.Education.Models;
using Education.Domain.UnitOfWork.Education;
namespace Education.Application.EducationCommands.Commands.Update;

public class UpdateEducationCommandHandler : IRequestHandler<UpdateEducationCommand, bool>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IReadUnitOfWork _readUnitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateEducationCommandHandler> _logger;

    public UpdateEducationCommandHandler(IWriteUnitOfWork writeUnitOfWork, IReadUnitOfWork readUnitOfWork, IMapper mapper, ILogger<UpdateEducationCommandHandler> logger)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _readUnitOfWork = readUnitOfWork;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<bool> Handle(UpdateEducationCommand request, CancellationToken cancellationToken)
    {
        var result = await _readUnitOfWork.EducationReadRepository.GetEducationAsync(request.Id);
        if (result == null)
        {
            throw new NotFoundException(nameof(result), request.Id);
        }
        var mappedComment = _mapper.Map<Training>(request);
        await _writeUnitOfWork.EducationWriteRepository.UpdateEducation_CommentAsync(mappedComment);
        _logger.LogInformation($"Product {result.Id} is successfully updated.");
        return true;
    }
}