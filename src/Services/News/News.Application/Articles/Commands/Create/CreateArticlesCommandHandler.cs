using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using News.Application.NewsCommands.Commands;
using News.Application.NewsCommands.Commands.Create;
using News.Domain.Dtos.News;
using News.Domain.News.Models;
using News.Domain.UnitOfWork.News;

namespace News.Application.Articles.Commands.Create;

public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, NewsArticleDto>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateAuthorCommandHandler> _logger;
    private readonly IPublishEndpoint _publishEndPoint;


    public CreateAuthorCommandHandler(IWriteUnitOfWork writeUnitOfWork, IMapper mapper, IPublishEndpoint publishEndpoint, ILogger<CreateAuthorCommandHandler> logger)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _mapper = mapper;
        _logger = logger;
        _publishEndPoint = publishEndpoint;
    }

    public async Task<NewsArticleDto> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        var mappedComment = _mapper.Map<News_Article>(request);
        var result = await _writeUnitOfWork.NewsWriteRepository.AddNews_ArticleAsync(mappedComment);
        return _mapper.Map<NewsArticleDto>(result);
    }
}