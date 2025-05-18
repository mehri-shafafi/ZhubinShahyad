using MediatR;
using Microsoft.Extensions.Logging;
using Menus.Application.Exception;
using Menus.Domain.UnitOfWork.Menu;

namespace Menus.Application.Menus.Commands.Menu.DeleteMedical;


public class DeleteMenuCommandHandler : IRequestHandler<DeleteMenuCommand, bool>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IReadUnitOfWork _readUnitOfWork;

    private readonly ILogger<DeleteMenuCommandHandler> _logger;

    public DeleteMenuCommandHandler(IWriteUnitOfWork writeUnitOfWork, IReadUnitOfWork readUnitOfWork, ILogger<DeleteMenuCommandHandler> logger)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _readUnitOfWork = readUnitOfWork;
        _logger = logger;
    }
    public async Task<bool> Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
    {
        var Menu = await _readUnitOfWork.MenuReadRepository.FetchMenuEntityAsync(request.Id);
        if (Menu == null)
        {
            throw new NotFoundException("Menu", request.Id);
        }

        await _writeUnitOfWork.MenuWriteRepository.DeleteMenuItemAsync(Menu);

        return true;


    }
}

