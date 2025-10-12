using Contact.Domain.Dtos.Contact;
using MediatR;

namespace Contact.Application.Contact.Commands.Contact.UpdateContact;

public class UpdateCommand : ContactReqDto, IRequest<bool>
{

}