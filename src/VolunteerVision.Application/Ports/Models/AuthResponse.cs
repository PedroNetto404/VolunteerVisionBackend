using System.Text.Json.Serialization;

namespace VolunteerVision.Application.Ports.Models;

public record AuthResponse
{
    [JsonPropertyName("access_token")]
    public required string AccessToken { get; init; }

    [JsonPropertyName("access_token_expires_in")]
    public required long AccessTokenExpiresIn { get; init; }

    [JsonPropertyName("refresh_token")]
    public required string RefreshToken { get; init; }

    [JsonPropertyName("refresh_token_expires_in")]
    public required long RefreshTokenExpiresIn { get; init; }

    [JsonPropertyName("token_type")]
    public string TokenType { get; } = "Bearer";

    public static implicit operator AuthResponse((Token acessToken, Token refreshToken) tokens) =>
        new()
        {
            AccessToken = tokens.acessToken.Value,
            AccessTokenExpiresIn = tokens.acessToken.Expiration,
            RefreshToken = tokens.refreshToken.Value,
            RefreshTokenExpiresIn = tokens.refreshToken.Expiration
        };
}