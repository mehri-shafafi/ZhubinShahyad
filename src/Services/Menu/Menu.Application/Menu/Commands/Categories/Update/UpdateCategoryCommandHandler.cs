using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Menus.Application.Exception;
using Menus.Application.Menus.Commands.Categories.Update;
using Menus.Domain.UnitOfWork.Menu;
namespace Menus.Application.Menus.Commands.Categories.Update;

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
        var Menu = await _readUnitOfWork.MenuReadRepository.FetchMenuCategoryAsync(request.Id);
        if (Menu == null)
        {
            throw new NotFoundException(nameof(Menu), request.Id);
        }
        var updatedMenu = _mapper.Map<Domain.Menu.Models.MenuCategory>(request);
        await _writeUnitOfWork.MenuWriteRepository.UpdateMenuCategoriesAsync(updatedMenu);
        _logger.LogInformation($"Menu {Menu.Id} is successfully updated.");
        return true;
    }
}