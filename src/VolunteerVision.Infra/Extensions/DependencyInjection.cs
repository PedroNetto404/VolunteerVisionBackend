using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace VolunteerVision.Infra.Extensions;

public static partial class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration) =>
        services
            .AddHostedServices(configuration)
            .AddDatabase(configuration)
            .AddAuth(configuration);
}
