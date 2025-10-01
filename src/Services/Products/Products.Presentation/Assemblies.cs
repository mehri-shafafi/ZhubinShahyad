using Products.Application.Products.Commands.Categories.Create;
using Products.Application.Products.Commands.Product.CreateMedical;
using Products.Domain.Products.Entity;
using Products.Domain.Products.Models;
using Products.Infrastructure;
using System.Reflection;

namespace Products.Presentation;

public static class Assemblies
{
    public static readonly Assembly EntityAssembly = typeof(ProductModel).Assembly;
    public static readonly Assembly EntityCategureisAssembly = typeof(ProductCategory).Assembly;
    public static readonly Assembly ApplicationCategureisAssembly = typeof(CreateCategoryCommand).Assembly;
    public static readonly Assembly ApplicationProductAssembly = typeof(CreateProductCommand).Assembly;
    public static readonly Assembly InfrastructureAssembly = typeof(ProductDbContext).Assembly;
}

