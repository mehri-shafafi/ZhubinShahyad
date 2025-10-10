using Gallery.Application.Gallery.Commands.Base.CreateGallery;
using Gallery.Domain.Gallery.Models;
using Gallery.Infrastructure;
using System.Reflection;

namespace Gallery.Presentation;

public static class Assemblies
{
    public static readonly Assembly EntityAssembly = typeof(GalleryEntity).Assembly;
    public static readonly Assembly ApplicationGalleryAssembly = typeof(CreateGalleryCommand).Assembly;
    public static readonly Assembly InfrastructureAssembly = typeof(GalleryDbContext).Assembly;
}

