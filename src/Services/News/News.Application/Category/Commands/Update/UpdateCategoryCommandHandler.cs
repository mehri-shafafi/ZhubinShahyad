using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using News.Application.Author.Commands.Update;
using News.Application.Exception;
using News.Domain.News.Models;
using News.Domain.UnitOfWork.News;
namespace News.Application.Category.Commands.Update;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IReadUnitOfWork _readUnitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateCategoryCommandHandler> _logger;

    public UpdateCategoryCommandHandler(IWriteUnitOfWork writeUnitOfWork, IReadUnitOfWork readUnitOfWork, IMapper mapper, ILogger<UpdateCategoryCommandHandler> logger)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _readUnitOfWork = readUnitOfWork;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var result = await _readUnitOfWork.NewsReadRepository.GetNewsCategoryAsync(request.Id);
        if (result == null)
        {
            throw new NotFoundException(nameof(result), request.Id);
        }
        var mappedComment = _mapper.Map<News_Category>(request);
        await _writeUnitOfWork.NewsWriteRepository.UpdateNews_CategoryAsync(mappedComment);
        _logger.LogInformation($"Product {result.Id} is successfully updated.");
        return true;
    }
}