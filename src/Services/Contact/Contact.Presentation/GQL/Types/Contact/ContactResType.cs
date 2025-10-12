using Contact.Domain.Dtos.Contact;
using GraphQL.Types;

namespace Contact.Presentation.GQL.Types.Contact
{
    public class ContactResType : ObjectGraphType<ContactResDto>
    {

        public ContactResType()
        {
            Field(x => x.Name, type: typeof(StringGraphType));
            Field(x => x.Message, type: typeof(StringGraphType));
            Field(x => x.Subject, type: typeof(StringGraphType));
            Field(x => x.ModificationDateTime, type: typeof(StringGraphType));
            Field(x => x.IsRead, type: typeof(BooleanGraphType));
            Field(x => x.CategoryId, type: typeof(IdGraphType));
            Field(x => x.CreationDateTime, type: typeof(DecimalGraphType));
            Field(x => x.ModificationDateTimeShamsi, type: typeof(IntGraphType));
        }
    }
}
