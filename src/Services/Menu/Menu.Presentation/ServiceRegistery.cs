using EventBus.Messages.Events;
using FluentValidation;
using MediatR;
using Menus.Application.Behaviours;
using Menus.Domain.UnitOfWork.Menu;
using Menus.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

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
        builder.Services.AddAutoMapper(cfg => { }, Assemblies.InfrastructureAssembly);
        builder.Services.AddDbContext<MenuDbContext>(option =>
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
        //builder.Services.AddMassTransit(x =>
        //{

        //    x.UsingRabbitMq((ctx, cfg) =>
        //    {
        //        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
        //    });

        //    x.AddConsumers(typeof(IntegrationBaseEvent).Assembly);
        //});
        // OPTIONAL, but can be used to configure the bus options
        //builder.Services.AddOptions<MassTransitHostOptions>()
        //    .Configure(options =>
        //    {
        //        // if specified, waits until the bus is started before
        //        // returning from IHostedService.StartAsync
        //        // default is false
        //        options.WaitUntilStarted = true;

        //        // if specified, limits the wait time when starting the bus
        //        options.StartTimeout = TimeSpan.FromSeconds(10);

        //        // if specified, limits the wait time when stopping the bus
        //        options.StopTimeout = TimeSpan.FromSeconds(30);
        //    });

        return builder.Services;

    }
}

