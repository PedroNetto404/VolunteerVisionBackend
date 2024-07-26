using Microsoft.Extensions.DependencyInjection;

namespace VolunteerVision.Domain.Core.Attributes;

public abstract class ServiceAttribute : Attribute
{
    public abstract ServiceLifetime Lifetime { get; }
}
