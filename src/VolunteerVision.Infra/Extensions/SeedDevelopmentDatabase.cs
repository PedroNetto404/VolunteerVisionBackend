using VolunteerVision.Domain.Resources.Users;
using VolunteerVision.Domain.Resources.Users.ValueObjects;
using VolunteerVision.Infra.Persistence;
using VolunteerVision.Infra.Security.Services;

namespace VolunteerVision.Infra.Extensions;

internal static class SeedDevelopmentDatabase
{
    public static async Task SeedAsync(this VolunteerVisionDbContext context)
    {
        await AddUsersAsync(context);
        await context.SaveChangesAsync();
    }

    private static async Task AddUsersAsync(VolunteerVisionDbContext context)
    {
        var hasher = new Sha256PasswordHasher();
        await context.Set<User>().AddRangeAsync(
            Enumerable.Range(0, 10).Select(p =>
                User.CreateCommon(
                    Guid.NewGuid().ToString(),
                    Email.New("pedro_teste@gmail.com"),
                    Password.New("Strong@123!@!#"),
                    hasher).Value)
            .ToArray());
    }
}
