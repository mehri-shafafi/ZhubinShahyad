using Contact.Application.Contact.Commands.Base.CreateContact;
using Contact.Application.Contact.Commands.Base.DeleteContact;
using Contact.Application.Contact.Commands.Contact.UpdateContact;
using Contact.Domain.Contact.Models;
using Contact.Infrastructure;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System.Reflection;

namespace Contact.Presentation;

public static class Assemblies
{
    public static readonly Assembly EntityAssembly = typeof(ContactEntity).Assembly;
    public static readonly Assembly CreateAssembly = typeof(CreateCommand).Assembly;
    public static readonly Assembly UpdateAssembly = typeof(UpdateCommand).Assembly;
    public static readonly Assembly DeleteAssembly = typeof(DeleteCommand).Assembly;
    public static readonly Assembly InfrastructureAssembly = typeof(ContactDbContext).Assembly;
}

