using System.Collections.Concurrent;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VolunteerVision.Domain.Core.Abstractions;
using VolunteerVision.Infra.Persistence;

namespace VolunteerVision.Infra.Extensions;

public static partial class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration) =>
        services
            .AddDbContext<VolunteerVisionDbContext>(options =>
            {
                options
                    .UseNpgsql(
                        Environment.GetEnvironmentVariable("DATABASE_URL") ?? throw new InvalidOperationException("DATABASE_URL environment variable not set"),
                        b => b.MigrationsAssembly(typeof(VolunteerVisionDbContext).Assembly.FullName))
                    .UseSnakeCaseNamingConvention();
            })
            .AddAuth(configuration)
            .AddDefinedServices(configuration)
            .AddSingleton<ConcurrentQueue<IDomainEvent>>();

}
