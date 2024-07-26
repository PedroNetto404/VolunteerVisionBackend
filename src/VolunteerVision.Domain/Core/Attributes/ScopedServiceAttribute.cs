using Microsoft.Extensions.DependencyInjection;

namespace VolunteerVision.Domain.Core.Attributes;

public class ScopedServiceAttribute : ServiceAttribute
{
    public override ServiceLifetime Lifetime => ServiceLifetime.Scoped;
}
