using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using VolunteerVision.Application;
using VolunteerVision.Application.Ports;
using VolunteerVision.Application.Ports.Models;
using VolunteerVision.Domain.Core.Attributes;
using VolunteerVision.Domain.Resources.Users;
using VolunteerVision.Infra.Security.Options;

namespace VolunteerVision.Infra.Security.Services;

[ScopedService]
internal class AuthTokenProvider(
    IOptions<JwtOptions> options
) : ITokenProvider
{
    public (Token AccessToken, Token RefreshToken) GenerateTokens(User user)
    {
        var accessTokenExpiration = DateTimeOffset.UnixEpoch.AddMinutes(options.Value.AccessTokenExpirationInMinutes);
        var refreshTokenExpiration = DateTimeOffset.UnixEpoch.AddMinutes(options.Value.RefreshTokenExpirationInMinutes);

        var tokenDescription = new JwtSecurityToken(
            issuer: options.Value.Issuer,
            audience: options.Value.Audience,
            expires: accessTokenExpiration.DateTime,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.Secret)), SecurityAlgorithms.HmacSha256)
        );

        var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenDescription);
        var refreshToken = GenerateRefreshToken();

        return (
            Token.Create(accessToken, accessTokenExpiration.ToUnixTimeSeconds()),
            Token.Create(refreshToken, refreshTokenExpiration.ToUnixTimeSeconds())
        );
    }

    private static string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);

        return Convert.ToBase64String(randomNumber);
    }
}
