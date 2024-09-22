using VolunteerVision.Api.Endpoints;

namespace VolunteerVision.Api.Extensions;

public static class Pipeline
{
    public static WebApplication UsePipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app
                .UseSwagger()
                .UseSwaggerUI()
                .UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/error");
            app.UseHsts();
        }

        app
            .UseHttpsRedirection()
            .UseAuthentication()
            .UseAuthorization();

        app.UseRouting();

        app.MapControllers();
        app.MapAuthEndpoints();
        app.MapGet("/", async (context) =>
        {
            if (app.Environment.IsDevelopment())
            {
                context.Response.Redirect("/swagger", true);
                return;
            }

            await context.Response.WriteAsJsonAsync(new
            {
                Message = "Api UP!!!"
            });
        });

        return app;
    }
}
