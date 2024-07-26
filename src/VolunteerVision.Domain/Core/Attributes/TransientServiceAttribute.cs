using Microsoft.Extensions.DependencyInjection;

namespace VolunteerVision.Domain.Core.Attributes;

public sealed class TransientServiceAttribute : ServiceAttribute
{
    public override ServiceLifetime Lifetime => ServiceLifetime.Transient;
}
