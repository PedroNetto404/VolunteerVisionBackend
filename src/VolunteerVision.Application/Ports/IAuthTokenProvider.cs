using System.Text.Json.Serialization;

namespace VolunteerVision.Application.Ports;

/// <summary>
/// Interface for generating authentication tokens.
/// </summary>
public interface IAuthTokenProvider
{
    Token GenerateToken(string userId);

    public sealed record Token(
        [property: JsonPropertyName("auth_token")] string AuthToken,
        [property: JsonPropertyName("expires_in")] int ExpiresIn,
        [property: JsonPropertyName("token_type")] string TokenType,
        [property: JsonPropertyName("refresh_token")] string RefreshToken,
        [property: JsonPropertyName("refresh_token_expires_in")] int RefreshTokenExpiresIn
    );
}