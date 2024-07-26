using Microsoft.Extensions.DependencyInjection;

namespace VolunteerVision.Domain.Core.Attributes;

public sealed class SingletonServiceAttribute : ServiceAttribute
{
    public override ServiceLifetime Lifetime => ServiceLifetime.Singleton;
}
