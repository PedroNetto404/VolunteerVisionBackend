using VolunteerVision.Domain.Core.Result;
using VolunteerVision.Domain.Resources.Users.ValueObjects;

namespace VolunteerVision.Application.Ports;

/// <summary>
/// Port for authenticating users.
/// </summary>
public interface IAuthProvider
{
    Task<Result<AuthModel>> AuthenticateAsync(string email, string password);
    Task<Result<AuthModel>> RefreshTokenAsync(string refreshToken);
    Task<Result<AuthModel>> RegisterAsync(string name, string email, string password);
}

public sealed record AuthModel(
    string AccessTokem,
    long AccessTokenExpiresIn,
    string RefreshToken,
    long RefreshTokenExpiresIn,
    string TokenType = "Bearer"
)
{
    public static AuthModel Create(Token accessToken, Token refreshToken) =>
        new(
            accessToken.Value,
            accessToken.Expiration,
            refreshToken.Value,
            refreshToken.Expiration
        );
}