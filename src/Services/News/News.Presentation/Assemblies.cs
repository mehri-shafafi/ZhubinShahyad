using News.Application.NewsCommands.Commands.Create;
using News.Domain.Dtos.News;
using News.Infrastructure;
using System.Reflection;

namespace News.Presentation
{
    public static class Assemblies
    {
        public static readonly Assembly EntityAssembly = typeof(NewsCommentDto).Assembly;
        public static readonly Assembly ApplicationAssembly = typeof(CreateArticlesCommand).Assembly;
        public static readonly Assembly InfrastructureAssembly = typeof(NewsDbContext).Assembly;
    }
}
