using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace VolunteerVision.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services,
        IConfiguration configuration) => services.AddMediatR(config =>
    {
        config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
    });
}
