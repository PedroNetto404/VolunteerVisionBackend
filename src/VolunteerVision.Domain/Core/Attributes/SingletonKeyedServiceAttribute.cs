using Microsoft.Extensions.DependencyInjection;

namespace VolunteerVision.Domain.Core.Attributes;

public sealed class SingletonKeyedServiceAttribute(object key) : KeyedServiceAttribute(key)
{
    public override ServiceLifetime Lifetime => ServiceLifetime.Singleton;
}



