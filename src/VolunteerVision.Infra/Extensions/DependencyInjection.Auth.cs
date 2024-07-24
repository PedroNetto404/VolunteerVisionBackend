using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using VolunteerVision.Infra.Security.Models;

namespace VolunteerVision.Infra.Extensions;

public static partial class DependencyInjection
{
    private static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddOptions<JwtOptions>()
            .BindConfiguration(JwtOptions.SectionName)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(opt =>
        {
            var jwtOptions = configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>() ??
                throw new InvalidOperationException("jwt options is required");

            opt.TokenValidationParameters = new()
            {
                ValidateLifetime = true,
                ValidAlgorithms = [SecurityAlgorithms.HmacSha256],
                ValidateAudience = true,
                ValidAudience = jwtOptions.Audience,
                ValidateIssuer = true,
                ValidIssuer = jwtOptions.Issuer,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Secret))
            };
        });

        return services;
    }
}
