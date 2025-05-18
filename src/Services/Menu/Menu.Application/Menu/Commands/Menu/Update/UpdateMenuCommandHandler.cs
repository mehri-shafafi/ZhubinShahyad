using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Menus.Application.Exception;
using Menus.Domain.UnitOfWork.Menu;
namespace Menus.Application.Menus.Commands.Menu.UpdateMenu;

public class UpdateMenuCommandHandler : IRequestHandler<UpdateMenuCommand, bool>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IReadUnitOfWork _readUnitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateMenuCommandHandler> _logger;

    public UpdateMenuCommandHandler(IWriteUnitOfWork writeUnitOfWork, IReadUnitOfWork readUnitOfWork, IMapper mapper, ILogger<UpdateMenuCommandHandler> logger)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _readUnitOfWork = readUnitOfWork;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<bool> Handle(UpdateMenuCommand request, CancellationToken cancellationToken)
    {
        var Menu = await _readUnitOfWork.MenuReadRepository.FetchMenuEntityAsync(request.Id);
        if (Menu == null)
        {
            throw new NotFoundException(nameof(Menu), request.Id);
        }
        var updatedMenu = _mapper.Map<Domain.Menu.Models.MenuItem>(request);
        await _writeUnitOfWork.MenuWriteRepository.UpdateMenuItemAsync(updatedMenu);
        _logger.LogInformation($"Menu {Menu.Id} is successfully updated.");
        return true;
    }
}