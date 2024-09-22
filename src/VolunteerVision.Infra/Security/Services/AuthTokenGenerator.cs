using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using VolunteerVision.Application.Ports;
using VolunteerVision.Domain.Core.Attributes;
using VolunteerVision.Domain.Resources.Users;
using VolunteerVision.Domain.Resources.Users.ValueObjects;
using VolunteerVision.Infra.Security.Options;

namespace VolunteerVision.Infra.Security.Services;

[ScopedService]
internal class AuthTokenGenerator(
    IOptions<JwtOptions> options
) : ITokenGenerator
{
    public Token GenerateAccessTokenFor(User user)
    {
        var accessTokenExpiration =
            DateTimeOffset.UtcNow
                .AddMinutes(options.Value.AccessTokenExpirationInMinutes);

        var handler = new JwtSecurityTokenHandler();

        var key = Encoding.UTF8.GetBytes(options.Value.Secret);
        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = GenerateClaims(user),
            Expires = accessTokenExpiration.DateTime,
            Issuer = options.Value.Issuer,
            Audience = options.Value.Audience,
            SigningCredentials = credentials
        };

        var accessToken = handler.WriteToken(handler.CreateToken(tokenDescriptor));
        return new Token(accessToken, accessTokenExpiration.ToUnixTimeSeconds());
    }

    public Token GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);

        var refreshTokenExpiration =
            DateTimeOffset.UtcNow
                .AddMinutes(options.Value.RefreshTokenExpirationInMinutes)
                .ToUnixTimeSeconds();

        return new Token(Convert.ToBase64String(randomNumber), refreshTokenExpiration);
    }

    private static ClaimsIdentity GenerateClaims(User user)
    {
        Claim[] claims =
        [
            new(ClaimTypes.Email, user.Email.Value),
            new(ClaimTypes.Name, user.Name),
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Role, user.Role.Name)
        ];

        var identity = new ClaimsIdentity();
        identity.AddClaims(claims);

        return identity;
    }
}
