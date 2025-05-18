using Menus.Application.Menu.Commands.Categories.Create;
using Menus.Application.Menu.Commands.Menu.Create;
using Menus.Domain.Menu.Models;
using Menus.Infrastructure;
using System.Reflection;

namespace Products.Presentation;

public static class Assemblies
{
    public static readonly Assembly EntityAssembly = typeof(MenuItem).Assembly;
    public static readonly Assembly EntityCategureisAssembly = typeof(MenuCategory).Assembly;
    public static readonly Assembly ApplicationCategureisAssembly = typeof(CreateCategoryCommand).Assembly;
    public static readonly Assembly ApplicationProductAssembly = typeof(CreateMenuCommand).Assembly;
    public static readonly Assembly InfrastructureAssembly = typeof(MenuDbContext).Assembly;
}

