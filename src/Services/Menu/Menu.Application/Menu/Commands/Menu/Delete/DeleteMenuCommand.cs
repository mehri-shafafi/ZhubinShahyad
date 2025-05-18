using MediatR;

namespace Menus.Application.Menus.Commands.Menu.DeleteMedical;

public class DeleteMenuCommand : IRequest<bool>
{
    public int Id { get; set; }
}