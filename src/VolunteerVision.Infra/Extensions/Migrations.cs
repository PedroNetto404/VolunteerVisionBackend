using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VolunteerVision.Infra.Persistence;

namespace VolunteerVision.Infra.Extensions;

public static class Migrations
{
    public static async Task SetupDatabaseAsync(this WebApplication app)
    {
        try
        {
            using var scope = app.Services.CreateScope();
        
            await using var context = scope.ServiceProvider.GetRequiredService<VolunteerVisionDbContext>();
            await context.Database.MigrateAsync();

            if (!app.Environment.IsDevelopment())
            {
                return;
            }

            await context.SeedAsync();
        }
        catch (Exception)
        {
            //ignored
        }
    }
}
