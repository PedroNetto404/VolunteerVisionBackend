using System.Text.Json;

namespace VolunteerVision.Api.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        AddControllers(services);
        AddSwagger(services);
        
        return services;
    }

    private static void AddSwagger(IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    private static void AddControllers(IServiceCollection services)
    {
        var builder = services.AddControllers();

        builder.AddJsonOptions(static config =>
        {
            config.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
        });

        services.AddRouting(static config =>
        {
            config.LowercaseUrls = true;
            config.LowercaseQueryStrings = true;
        });
    }
}
