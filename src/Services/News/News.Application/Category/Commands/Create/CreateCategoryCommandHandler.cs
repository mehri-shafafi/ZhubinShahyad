using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using News.Application.Dtos.News;
using News.Domain.News.Models;
using News.Domain.UnitOfWork.News;

namespace News.Application.Category.Commands.Create;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, NewsCategoryDto>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateCategoryCommandHandler> _logger;


    public CreateCategoryCommandHandler(IWriteUnitOfWork writeUnitOfWork, IMapper mapper, ILogger<CreateCategoryCommandHandler> logger)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<NewsCategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var mappedComment = _mapper.Map<News_CategoryModel>(request);
        var result = await _writeUnitOfWork.NewsWriteRepository.AddNews_CategoryAsync(mappedComment);
        return _mapper.Map<NewsCategoryDto>(result);
    }
}