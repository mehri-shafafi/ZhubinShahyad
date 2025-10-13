using Contact.Application.Contact.Commands.Base.CreateContact;
using Contact.Application.Contact.Commands.Contact.UpdateContact;
using Contact.Domain.Dtos.Contact;
using Contact.Presentation.GQL.Types.Contact;
using GraphQL;
using GraphQL.Types;
using MediatR;

namespace Contact.Presentation.GQL.Mutations
{
    public static class ContactSMutations
    {
        public static void ContactMutations(this ObjectGraphType schema, IMediator mediator)
        {
            schema.FieldAsync<ContactResType>(
                "addContact",
                "Is used to add a new Contact to the database",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ContactReqType>> { Name = "ContactInput", Description = "Contact input parameter" }),
                resolve: async context =>
                {
                    var addProduct = context.GetArgument<CreateCommand>("ContactInput");
                    bool addProductRes = false;
                    try
                    {
                        addProductRes = await mediator.Send(addProduct);
                    }
                    catch (Exception ex)
                    {
                        context.Errors.Add(new ExecutionError(ex.Message));
                        return null;
                    }

                    return addProductRes;
                }

            );
            schema.FieldAsync<BooleanGraphType>(
                "updateProduct",
                "Is used to update a  product to the database",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ContactReqType>> { Name = "productInput", Description = "Product input parameter" }),

                resolve: async context =>
                {
                    UpdateCommand updateProduct = context.GetArgument<UpdateCommand>("productInput");
                    bool updateProductRes;
                    try
                    {
                        updateProductRes = await mediator.Send(updateProduct);
                    }
                    catch (Exception ex)
                    {

                        context.Errors.Add(new ExecutionError(ex.Message));
                        return null;

                    }

                    return updateProductRes;
                });
        }
    }
}
