using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using VolunteerVision.Application.Ports;
using VolunteerVision.Infra.Persistence;
using VolunteerVision.Infra.Security.Models;
using VolunteerVision.Infra.Security.Services;

namespace VolunteerVision.Infra;

public static class DepedencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<VolunteerVisionDbContext>(options =>
        {
            options.UseNpgsql(
                configuration.GetConnectionString("Default"),
                b => b.MigrationsAssembly(typeof(VolunteerVisionDbContext).Assembly.FullName));
        });

        services.AddScoped<IAuthTokenProvider, AuthTokenProvider>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }

    private static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddOptions<JwtOptions>()
            .BindConfiguration(JwtOptions.SectionName)
            .ValidateDataAnnotations();

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

    public static WebApplication ApplyMigrations(this WebApplication app)
    {
        //TODO: implement the following code
        return app;
    }
}
