using Microsoft.Extensions.DependencyInjection;

namespace VolunteerVision.Domain.Core.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public abstract class ServiceAttribute : Attribute
{
    public abstract ServiceLifetime Lifetime { get; }
}