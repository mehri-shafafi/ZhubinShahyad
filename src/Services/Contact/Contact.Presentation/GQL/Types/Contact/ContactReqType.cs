using GraphQL.Types;

namespace Contact.Presentation.GQL.Types.Contact
{
    public class ContactReqType : InputObjectGraphType
    {
        public ContactReqType()
        {
            Name = nameof(ContactReqType);
            Field<IdGraphType>("Id");

      
        }
    }
}
