using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace VolunteerVision.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddControllers();

        return services.AddSwagger();
    }

    private static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(config => config.SwaggerDoc("v1", new()
        {
            Title = "VolunteerVision.Api",
            Version = "v1",
            Contact = new()
            {
                Name = "VolunteerVision",
                Email = "pedronetto31415@gmail.com"
            }
        }));

        return services;
    }



    public static WebApplication ConfigurePipeline(this WebApplication app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger(config =>
            {
                config.RouteTemplate = "/swagger/{documentName}/swagger.json";
                config.SerializeAsV2 = true;
            });
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VolunteerVision.Api v1"));
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
}