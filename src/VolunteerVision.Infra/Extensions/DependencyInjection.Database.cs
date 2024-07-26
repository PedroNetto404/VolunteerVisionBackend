using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VolunteerVision.Infra.Persistence;

namespace VolunteerVision.Infra.Extensions;

public static partial class DependencyInjection
{
    private static IServiceCollection AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration) =>
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
}
