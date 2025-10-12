using Contact.Domain.Dtos.Contact;
using MediatR;

namespace Contact.Application.Contact.Commands.Base.CreateContact;


public class CreateCommand : ContactReqDto, IRequest<ContactResDto>
{
}