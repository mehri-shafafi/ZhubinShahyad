using AutoMapper;
using Education.Domain.Education.Dtos;
using Education.Domain.Education.Models;
using Education.Domain.UnitOfWork.Education;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Education.Application.EducationCommands.Commands.Create;

public class CreateEducationCommandHandler : IRequestHandler<CreateEducationCommand, TrainingDto>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateEducationCommandHandler> _logger;


    public CreateEducationCommandHandler(IWriteUnitOfWork writeUnitOfWork, IMapper mapper,  ILogger<CreateEducationCommandHandler> logger)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<TrainingDto> Handle(CreateEducationCommand request, CancellationToken cancellationToken)
    {
        var mappedComment = _mapper.Map<Training>(request);
        var result = await _writeUnitOfWork.EducationWriteRepository.AddEducation_CommentAsync(mappedComment);
        return _mapper.Map<TrainingDto>(result);
    }
}