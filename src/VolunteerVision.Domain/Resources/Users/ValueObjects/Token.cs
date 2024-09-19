using VolunteerVision.Domain.Core.Error;
using VolunteerVision.Domain.Resources.Users.Errors;

namespace VolunteerVision.Domain.Resources.Users.ValueObjects;

/// <summary>
/// Represents a token and its expiration date.
/// </summary>
/// <param name="Value"></param>
/// <param name="Expiration"></param>
public record Token
{
    public string Value { get; }

    public long Expiration { get; }

    private Token(string value, long expiration) =>
        (Value, Expiration) = (value, expiration);

    public bool IsExpired =>
        DateTimeOffset.FromUnixTimeSeconds(Expiration) < DateTimeOffset.UtcNow;

    public static ErrorOr<Token> Create(string value, long expiration)
    {
        if (expiration < DateTimeOffset.UtcNow.ToUnixTimeSeconds())
        {
            return TokenExpired.Instance;
        }

        return new Token(value, expiration);
    }
}
