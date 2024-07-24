using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VolunteerVision.Infra.Persistence;

namespace VolunteerVision.Infra.Extensions;

public static partial class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration) =>
        services
            .AddDbContext<VolunteerVisionDbContext>()
            .ConfigureOptions<DbContextOptionsBuilderSetup>()
            .AddJwtAuthentication(configuration)
            .AddDefinedServices(configuration);

}
