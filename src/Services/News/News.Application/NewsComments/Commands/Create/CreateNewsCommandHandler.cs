using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using News.Domain.Dtos.News;
using News.Domain.News.Models;
using News.Domain.UnitOfWork.News;

namespace News.Application.NewsCommands.Commands.Create;

public class CreateNewsCommandHandler : IRequestHandler<CreateNewsCommand, NewsCommentDto>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateNewsCommandHandler> _logger;


    public CreateNewsCommandHandler(IWriteUnitOfWork writeUnitOfWork, IMapper mapper, ILogger<CreateNewsCommandHandler> logger)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<NewsCommentDto> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
    {
        var mappedComment = _mapper.Map<News_Comment>(request);
        var result = await _writeUnitOfWork.NewsWriteRepository.AddNews_CommentAsync(mappedComment);
        return _mapper.Map<NewsCommentDto>(result);
    }
}