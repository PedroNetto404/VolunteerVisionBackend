namespace VolunteerVision.Domain.Core.Attributes;

public abstract class KeyedServiceAttribute(object key) : ServiceAttribute
{
    public object Key { get; } = key;
}



