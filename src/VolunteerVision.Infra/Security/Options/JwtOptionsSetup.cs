using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace VolunteerVision.Infra.Security.Options;

internal sealed class JwtOptionsSetup(
    IOptions<JwtOptions> options) : IConfigureNamedOptions<JwtBearerOptions>
{
    private readonly JwtOptions _options = options.Value;
    public void Configure(JwtBearerOptions options)
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = _options.Issuer,
            ValidAudience = _options.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Secret))
        };
    }
    public void Configure(string? name, JwtBearerOptions options) => Configure(options);
}
