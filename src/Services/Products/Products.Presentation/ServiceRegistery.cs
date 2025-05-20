using EventBus.Messages.Events;
using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Application.Behaviours;
using Products.Domain;
using Products.Domain.UnitOfWork.Product;
using Products.Infrastructure;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Products.Domain.Products.Models;
using System.Text.Json;

namespace Products.Presentation;
public static class ServiceRegistery
{
    public static IServiceCollection AddServiceRegistery(this WebApplicationBuilder builder)
    {

        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            options.JsonSerializerOptions.WriteIndented = true;
        });
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        return builder.Services;
    }

    public static IServiceCollection AddInfrastructureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(Assemblies.InfrastructureAssembly);
        builder.Services.AddDbContext<ProductDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddScoped<IReadUnitOfWork, ReadUnitOfWork>();
        builder.Services.AddScoped<IWriteUnitOfWork, WriteUnitOfWork>();
        return builder.Services;
    }
    public static IServiceCollection AddApplicationServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddValidatorsFromAssembly(Assemblies.ApplicationCategureisAssembly);
        builder.Services.AddValidatorsFromAssembly(Assemblies.ApplicationProductAssembly);
        builder.Services.AddMediatR(Assemblies.ApplicationProductAssembly);
        builder.Services.AddMediatR(Assemblies.ApplicationCategureisAssembly);
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        return builder.Services;
    }
    public static IServiceCollection AddMessagingConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddMassTransit(x =>
        {

            x.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
            });

            x.AddConsumers(typeof(IntegrationBaseEvent).Assembly);
        });
        // OPTIONAL, but can be used to configure the bus options
        builder.Services.AddOptions<MassTransitHostOptions>()
            .Configure(options =>
            {
                // if specified, waits until the bus is started before
                // returning from IHostedService.StartAsync
                // default is false
                options.WaitUntilStarted = true;

                // if specified, limits the wait time when starting the bus
                options.StartTimeout = TimeSpan.FromSeconds(10);

                // if specified, limits the wait time when stopping the bus
                options.StopTimeout = TimeSpan.FromSeconds(30);
            });

        return builder.Services;

    }
    public static class DbSeeder
    {
        public static async Task SeedAsync(ProductDbContext context)
        {
            if (!context.Products.Any())
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string jsonPath = Path.Combine(baseDirectory, "SeedData", "ProductSeed.json");

                if (!File.Exists(jsonPath))
                    throw new FileNotFoundException($"Seed file not found: {jsonPath}");

                string json = File.ReadAllText(jsonPath);
                var products = JsonSerializer.Deserialize<List<ProductEntity>>(json);

                if (products is not null)
                {
                    foreach (var product in products)
                    {
                        product.CreationDateTime = DateTime.UtcNow;
                        product.ModificationDateTime = DateTime.UtcNow;
                        context.Products.Add(product);
                    }

                    await context.SaveChangesAsync();
                }
            }
        }
    }

}

