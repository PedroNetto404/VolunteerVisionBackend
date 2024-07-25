
namespace VolunteerVision.Api.Extensions;

public static class Pipeline
{
    public static WebApplication UsePipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger(config =>
            {
                config.RouteTemplate = "api/{documentName}/swagger.json";
            }).UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/api/v1/swagger.json", "VolunteerVision API v1");
                config.RoutePrefix = "api";
                config.DocumentTitle = "Koppler Labs Solidário - Ação #01";
            }).UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/error");
            app.UseHsts();
        }

        app
            .UseHttpsRedirection()
            .UseRouting()
            .UseAuthentication()
            .UseAuthorization()
            .UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/error", async context =>
                {
                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsync("An unexpected error occurred. Please try again later.");
                });


                endpoints.MapControllers();
            });

        return app;
    }
}
