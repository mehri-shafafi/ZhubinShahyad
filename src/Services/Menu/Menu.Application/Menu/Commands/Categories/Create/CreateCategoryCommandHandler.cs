using AutoMapper;
using MediatR;
using Menus.Application.Dtos.Menu;
using Menus.Domain.Menu.Models;
using Menus.Domain.UnitOfWork.Menu;
using Microsoft.Extensions.Logging;

namespace Menus.Application.Menu.Commands.Categories.Create;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, MenuCategoryDto>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateCategoryCommandHandler> _logger;
    //private readonly IPublishEndpoint _publishEndPoint;


    public CreateCategoryCommandHandler(IWriteUnitOfWork writeUnitOfWork, IMapper mapper, ILogger<CreateCategoryCommandHandler> logger)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<MenuCategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var newMenu = _mapper.Map<MenuCategory>(request);
        var addedMenu = await _writeUnitOfWork.MenuWriteRepository.AddMenuCategoriesAsync(newMenu);
        var result = _mapper.Map<MenuCategoryDto>(addedMenu);
        _logger.LogInformation($"Menu {addedMenu.Id} is successfully created.");




        return result;
    }
}