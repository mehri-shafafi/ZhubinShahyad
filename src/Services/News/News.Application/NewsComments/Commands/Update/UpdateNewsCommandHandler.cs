using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using News.Application.Exception;
using News.Application.News.Commands.News.Update;
using News.Domain.News.Models;
using News.Domain.UnitOfWork.News;
namespace News.Application.NewsCommands.Commands.Update;

public class UpdateNewsCommandHandler : IRequestHandler<UpdateNewsCommand, bool>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IReadUnitOfWork _readUnitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateNewsCommandHandler> _logger;

    public UpdateNewsCommandHandler(IWriteUnitOfWork writeUnitOfWork, IReadUnitOfWork readUnitOfWork, IMapper mapper, ILogger<UpdateNewsCommandHandler> logger)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _readUnitOfWork = readUnitOfWork;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<bool> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
    {
        var result = await _readUnitOfWork.NewsReadRepository.GetNewsCommentAsync(request.NewsCommentId);
        if (result == null)
        {
            throw new NotFoundException(nameof(result), request.NewsCommentId);
        }
        var mappedComment = _mapper.Map<News_Comment>(request);
        await _writeUnitOfWork.NewsWriteRepository.UpdateNews_CommentAsync(mappedComment);
        _logger.LogInformation($"Product {result.Id} is successfully updated.");
        return true;
    }
}