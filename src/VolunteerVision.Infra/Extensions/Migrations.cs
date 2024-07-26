using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VolunteerVision.Infra.Persistence;

namespace VolunteerVision.Infra.Extensions;

public static class Migrations
{
    public static WebApplication ApplyMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        
        try
        {
            using var context = services.GetRequiredService<VolunteerVisionDbContext>();
            context.Database.Migrate();
        }
        catch
        {
            // ignored
        }

        return app;
    }

    public static WebApplication AddSeedIfDevelopment(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
        {
            return app;
        }


        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<VolunteerVisionDbContext>();

        context.Seed();

        return app;
    }
}
