using VolunteerVision.Domain.Core.Maybe;

namespace VolunteerVision.Domain.Resources.Users.ValueObjects;

/// <summary>
/// Represents a token and its expiration date.
/// </summary>
/// <param name="Value"></param>
/// <param name="Expiration"></param>
public record Token(string Value, long Expiration)
{
    public bool Expired => DateTimeOffset.FromUnixTimeSeconds(Expiration) < DateTimeOffset.UtcNow;
}
