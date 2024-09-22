using Microsoft.Extensions.DependencyInjection;

namespace VolunteerVision.Domain.Core.Attributes;

public sealed class ScopedKeyedServiceAttribute(object key) : KeyedServiceAttribute(key)
{
    public override ServiceLifetime Lifetime => ServiceLifetime.Scoped;
}



