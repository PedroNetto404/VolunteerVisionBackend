using System.Text.Json;
using VolunteerVision.Api.Options;

namespace VolunteerVision.Api.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        AddControllers(services);
        AddSwagger(services);

        return services;
    }

    private static void AddSwagger(IServiceCollection services)
    {
        services.AddSwaggerGen(config =>
        {
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
