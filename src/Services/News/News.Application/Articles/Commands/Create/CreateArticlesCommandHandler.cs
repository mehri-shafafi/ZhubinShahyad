using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using News.Application.Dtos.News;
using News.Domain.News.Models;
using News.Domain.UnitOfWork.News;

namespace News.Application.Articles.Commands.Create;

public class CreateArticlesCommanddHandler : IRequestHandler<CreateArticlesCommand, bool>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateArticlesCommanddHandler> _logger;


    public CreateArticlesCommanddHandler(IWriteUnitOfWork writeUnitOfWork, IMapper mapper, ILogger<CreateArticlesCommanddHandler> logger)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<bool> Handle(CreateArticlesCommand request, CancellationToken cancellationToken)
    {
        var mappedComment = _mapper.Map<News_ArticleModel>(request);
        var result = await _writeUnitOfWork.NewsWriteRepository.AddNews_ArticleAsync(mappedComment);
        return result;
    }
}