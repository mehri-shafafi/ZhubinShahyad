using Contact.Domain.Dtos.Contact;
using MediatR;

namespace Contact.Application.Contact.Queries.GetContactList
{
    public class GetContactListQuery : IRequest<List<ContactResDto>>
    {

    }
}
