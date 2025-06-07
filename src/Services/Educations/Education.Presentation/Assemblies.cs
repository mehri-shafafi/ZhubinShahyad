using Education.Application.EducationCommands.Commands.Create;
using Education.Domain.Education.Models;
using Education.Infrastructure;
using System.Reflection;

namespace Education.Presentation
{
    public static class Assemblies
    {
        public static readonly Assembly EntityAssembly = typeof(Training).Assembly;
        public static readonly Assembly ApplicationAssembly_Training = typeof(CreateEducationCommand).Assembly;
        public static readonly Assembly InfrastructureAssembly = typeof(EducationDbContext).Assembly;
    }
}
