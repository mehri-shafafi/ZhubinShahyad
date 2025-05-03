using static Azure.Core.HttpHeader;
using System.Reflection;
using News.Domain.Dtos.News;
using News.Application.NewsCommands.Commands.Create;
using News.Infrastructure;

namespace News.Presentation
{
    public static class Assemblies
    {
        public static readonly Assembly EntityAssembly = typeof(NewsCommentDto).Assembly;
        public static readonly Assembly ApplicationAssembly = typeof(CreateNewsCommand).Assembly;
        public static readonly Assembly InfrastructureAssembly = typeof(ApplicationDbContext).Assembly;
    }
}
