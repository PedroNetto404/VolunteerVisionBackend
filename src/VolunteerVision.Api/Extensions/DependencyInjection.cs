using VolunteerVision.Api.Options;

namespace VolunteerVision.Api.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services)
    {
        services
            .AddOptions()
            .ConfigureOptions<SwaggerOptionsSetup>()
            .AddSwaggerGen()
            .AddControllers();

        return services;
    }
}
