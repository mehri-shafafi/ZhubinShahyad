using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using News.Domain.Dtos.News;
using News.Domain.News.Models;
using News.Domain.UnitOfWork.News;

namespace News.Application.Category.Commands.Create;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, NewsCategoryDto>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateCategoryCommandHandler> _logger;
    private readonly IPublishEndpoint _publishEndPoint;


    public CreateCategoryCommandHandler(IWriteUnitOfWork writeUnitOfWork, IMapper mapper, IPublishEndpoint publishEndpoint, ILogger<CreateCategoryCommandHandler> logger)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _mapper = mapper;
        _logger = logger;
        _publishEndPoint = publishEndpoint;
    }

    public async Task<NewsCategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var mappedComment = _mapper.Map<News_Category>(request);
        var result = await _writeUnitOfWork.NewsWriteRepository.AddNews_CategoryAsync(mappedComment);
        return _mapper.Map<NewsCategoryDto>(result);
    }
}