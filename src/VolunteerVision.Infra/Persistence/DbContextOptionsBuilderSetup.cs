using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace VolunteerVision.Infra.Persistence;

internal class DbContextOptionsBuilderSetup(
    IConfiguration configuration
) : IConfigureNamedOptions<DbContextOptionsBuilder<VolunteerVisionDbContext>>
{
    public void Configure(DbContextOptionsBuilder<VolunteerVisionDbContext> options) =>
        options.UseNpgsql(
            configuration.GetConnectionString("Default"),
            b => b.MigrationsAssembly(typeof(VolunteerVisionDbContext).Assembly.FullName)
        );


    public void Configure(string? name, DbContextOptionsBuilder<VolunteerVisionDbContext> options) =>
        Configure(options);
}
