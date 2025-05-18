using MediatR;
using Microsoft.Extensions.Logging;
using Menus.Application.Exception;
using Menus.Domain.UnitOfWork.Menu;

namespace Menus.Application.Menus.Commands.Categories.Delete;


public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
{
    private readonly IWriteUnitOfWork _writeUnitOfWork;
    private readonly IReadUnitOfWork _readUnitOfWork;

    private readonly ILogger<DeleteCategoryCommandHandler> _logger;

    public DeleteCategoryCommandHandler(IWriteUnitOfWork writeUnitOfWork, IReadUnitOfWork readUnitOfWork, ILogger<DeleteCategoryCommandHandler> logger)
    {
        _writeUnitOfWork = writeUnitOfWork;
        _readUnitOfWork = readUnitOfWork;
        _logger = logger;
    }
    public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var Menu = await _readUnitOfWork.MenuReadRepository.FetchMenuCategoryAsync(request.Id);
        if (Menu == null)
        {
            throw new NotFoundException("Menu", request.Id);
        }

        await _writeUnitOfWork.MenuWriteRepository.DeleteMenuCategoriesAsync(Menu);

        return true;


    }
}

