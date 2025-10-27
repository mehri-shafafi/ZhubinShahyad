using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using News.Application.Exception;
using News.Domain.News.Models;
using News.Domain.UnitOfWork.News;
namespace News.Application.Articles.Commands.Update;

public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand, bool>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IReadUnitOfWork _readUnitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateArticleCommandHandler> _logger;

    public UpdateArticleCommandHandler(IWriteUnitOfWork writeUnitOfWork, IReadUnitOfWork readUnitOfWork, IMapper mapper, ILogger<UpdateArticleCommandHandler> logger)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _readUnitOfWork = readUnitOfWork;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<bool> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
    {
        var result = await _readUnitOfWork.NewsReadRepository.GetNewsArticleAsync(request.Id);
        if (result == null)
        {
            throw new NotFoundException(nameof(result), request.Id);
        }
        var mappedComment = _mapper.Map<News_ArticleModel>(request);
        await _writeUnitOfWork.NewsWriteRepository.UpdateNews_ArticleAsync(mappedComment);
        _logger.LogInformation($"Product {result.Id} is successfully updated.");
        return true;
    }
}