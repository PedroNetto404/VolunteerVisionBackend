using System.Collections.Concurrent;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VolunteerVision.Domain.Core.Abstractions;
using VolunteerVision.Infra.BackgroundServices;
using VolunteerVision.Infra.Persistence;

namespace VolunteerVision.Infra.Extensions;

public static partial class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration) =>
        services
            .AddSingleton<DomainEventsDispatcher>()
            .AddSingleton<ConcurrentQueue<IDomainEvent>>()
            .AddHostedService<DomainEventsDispatcher>()
            .AddDbContext<VolunteerVisionDbContext>(options =>
            {
                options
                    .UseNpgsql(
                        configuration.GetConnectionString("Default") ??
                        throw new InvalidOperationException("Ensure appsettings.json contains a connection string..."),
                        b => b.MigrationsAssembly(typeof(VolunteerVisionDbContext).Assembly.FullName))
                    .UseSnakeCaseNamingConvention();
            })
            .AddAuth(configuration)
            .AddDefinedServices(configuration);
}
