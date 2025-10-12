using MediatR;

namespace Contact.Application.Contact.Commands.Base.DeleteContact;

public class DeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}