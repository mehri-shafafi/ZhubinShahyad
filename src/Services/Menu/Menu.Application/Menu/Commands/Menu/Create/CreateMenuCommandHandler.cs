using AutoMapper;
using MediatR;
using Menus.Domain.Dtos.Menu;
using Menus.Domain.Menu.Models;
using Menus.Domain.UnitOfWork.Menu;
using Microsoft.Extensions.Logging;

namespace Menus.Application.Menu.Commands.Menu.Create;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, MenuResDto>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateMenuCommandHandler> _logger;


    public CreateMenuCommandHandler(IWriteUnitOfWork writeUnitOfWork, IMapper mapper,  ILogger<CreateMenuCommandHandler> logger)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<MenuResDto> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        var newMenu = _mapper.Map<MenuItem>(request);
        var addedMenu = await _writeUnitOfWork.MenuWriteRepository.AddMenuItemAsync(newMenu);
        _logger.LogInformation($"Menu {addedMenu.Id} is successfully created.");

        return _mapper.Map<MenuResDto>(addedMenu);
    }
}