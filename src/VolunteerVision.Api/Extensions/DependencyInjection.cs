using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;
using VolunteerVision.Api.Options;

namespace VolunteerVision.Api.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        AddControllers(services);
        AddSwagger(services);
        AddApiVersioning(services);

        return services;
    }

    private static void AddApiVersioning(IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ApiVersionReader = ApiVersionReader.Combine(
                new QueryStringApiVersionReader("api-version"),
                new HeaderApiVersionReader("X-Version")
            );
        });
    }

    private static void AddSwagger(IServiceCollection services)
    {
        services.AddSwaggerGen(config =>
        {
            config.DocInclusionPredicate((version, desc) =>
            {
                var versions = desc.ActionDescriptor.EndpointMetadata.OfType<ApiVersionAttribute>();
                return versions.Any(v => $"v{v}" == version);
            });
        });

        services
         .AddOptions()
         .ConfigureOptions<SwaggerOptionsSetup>();

    }

    private static void AddControllers(IServiceCollection services)
    {
        var builder = services.AddControllers();

        builder.AddJsonOptions(config =>
        {
            config.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
        });

        services.AddRouting(config =>
        {
            config.LowercaseUrls = true;
            config.LowercaseQueryStrings = true;
            config.AppendTrailingSlash = true;
        });
    }
}
