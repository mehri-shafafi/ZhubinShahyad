using Contact.Application.Contact.Queries.GetContactList;
using Contact.Presentation.GQL.Types.Contact;
using GraphQL.Types;
using MediatR;

namespace Gallery.Presentation.GQL.Queries
{
    public static class ContactsQueries
    {
        public static void ContactQueries(this ObjectGraphType schema, IMediator mediator)
        {
            schema.Field<ListGraphType<ContactResType>>(
                "getProducts",
                description: "return list of prdoucts",
                resolve: context => mediator.Send(new GetContactListQuery())

            );

        }
    }
}
