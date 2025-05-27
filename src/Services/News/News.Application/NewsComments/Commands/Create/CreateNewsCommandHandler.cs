using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using News.Application.NewsCommands.Commands;
using News.Domain.Dtos.News;
using News.Domain.News.Models;
using News.Domain.UnitOfWork.News;

namespace News.Application.NewsCommands.Commands.Create;

public class CreateArticlesCommandHandler : IRequestHandler<CreateArticlesCommand, NewsCommentDto>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateArticlesCommandHandler> _logger;
    private readonly IPublishEndpoint _publishEndPoint;


    public CreateArticlesCommandHandler(IWriteUnitOfWork writeUnitOfWork, IMapper mapper, IPublishEndpoint publishEndpoint, ILogger<CreateArticlesCommandHandler> logger)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _mapper = mapper;
        _logger = logger;
        _publishEndPoint = publishEndpoint;
    }

    public async Task<NewsCommentDto> Handle(CreateArticlesCommand request, CancellationToken cancellationToken)
    {
        var mappedComment = _mapper.Map<News_Comment>(request);
        var result = await _writeUnitOfWork.NewsWriteRepository.AddNews_CommentAsync(mappedComment);
        return _mapper.Map<NewsCommentDto>(result);
    }
}