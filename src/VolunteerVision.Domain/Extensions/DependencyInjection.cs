using Microsoft.Extensions.DependencyInjection;

namespace VolunteerVision.Domain.Extensions;

public static partial class DependencyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        return services;
    }
}
