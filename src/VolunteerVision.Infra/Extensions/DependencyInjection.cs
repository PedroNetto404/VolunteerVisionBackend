using System.Collections.Concurrent;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VolunteerVision.Domain.Core.Abstractions;
using VolunteerVision.Domain.Ports;
using VolunteerVision.Infra.BackgroundServices;
using VolunteerVision.Infra.Persistence;
using VolunteerVision.Infra.Security.Options;

namespace VolunteerVision.Infra.Extensions;

public static partial class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        AddPersistence(services, configuration);
        AddAuthentication(services);

        return services;
    }


    private static void AddAuthentication(IServiceCollection services)
    {
        services
          .AddOptions<JwtOptions>()
          .BindConfiguration(JwtOptions.SectionName)
          .ValidateDataAnnotations()
          .ValidateOnStart();

        services.ConfigureOptions<JwtOptionsSetup>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer();
    }

    private static void AddPersistence(IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddSingleton<DomainEventsDispatcher>()
            .AddSingleton<ConcurrentQueue<IDomainEvent>>()
            .AddHostedService<DomainEventsDispatcher>();

        services
            .AddDbContext<VolunteerVisionDbContext>(options =>
            {
                options
                    .UseNpgsql(
                        configuration.GetConnectionString("Default") ??
                        throw new InvalidOperationException("Ensure appsettings.json contains a connection string..."),
                        b => b.MigrationsAssembly(typeof(VolunteerVisionDbContext).Assembly.FullName))
                    .UseSnakeCaseNamingConvention();

                using var serviceProvider = services.BuildServiceProvider();
                using var scope = serviceProvider.CreateScope();

                var interceptors = scope.ServiceProvider.GetServices<IInterceptor>();
                options.AddInterceptors(interceptors);
            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
}
