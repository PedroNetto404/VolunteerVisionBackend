using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VolunteerVision.Infra.Persistence;

namespace VolunteerVision.Infra.Extensions;

public static class Migrations
{
    public static async Task ApplyMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        
        try
        {
            await using var context = services.GetRequiredService<VolunteerVisionDbContext>();
            await context.Database.MigrateAsync();
        }
        catch
        {
            // ignored
        }
    }

    public static async Task AddSeedDatabaseIfDevelopmentAsync(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
        {
            return;
        }

        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<VolunteerVisionDbContext>();

        await context.SeedAsync();
    }
}
