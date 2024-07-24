using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VolunteerVision.Application.Ports;
using VolunteerVision.Infra.Security.Services;

namespace VolunteerVision.Infra.Extensions;

public static partial class DependencyInjection
{
    private static IServiceCollection AddDefinedServices(
        this IServiceCollection services,
        IConfiguration configuration) =>
        services
            .AddScoped<IAuthTokenProvider, AuthTokenProvider>()
            .AddScoped<IPasswordHasher, PasswordHasher>();
}
