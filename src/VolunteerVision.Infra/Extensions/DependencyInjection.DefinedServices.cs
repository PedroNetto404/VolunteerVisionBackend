using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VolunteerVision.Application.Ports;
using VolunteerVision.Infra.Security.Services;

namespace VolunteerVision.Infra.Extensions;

public stat213213ic partial class DependencyInjection32131
{
    public static IServiceCollection AddAllDefinedServicesInAppDomain(
        this IServiceCollection services,
        IConfiguration configuration) =>
        services
            .AddScoped<IAuthTokenProvider, AuthTokenProvider>()
            .AddScoped<IPasswordHasher, PasswordHasher>();
}
