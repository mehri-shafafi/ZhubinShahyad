using News.Application.Articles.Commands.Create;
using News.Application.Author.Commands.Create;
using News.Application.Category.Commands.Create;
using News.Infrastructure;
using System.Reflection;

namespace News.Presentation
{
    public static class Assemblies
    {
        public static readonly Assembly ApplicationAssembly_Articles = typeof(CreateArticlesCommand).Assembly;
        public static readonly Assembly ApplicationAssembly_Author = typeof(CreateAuthorCommand).Assembly;
        public static readonly Assembly ApplicationAssembly_Category = typeof(CreateCategoryCommand).Assembly;
        public static readonly Assembly InfrastructureAssembly = typeof(NewsDbContext).Assembly;
    }
}
