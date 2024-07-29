using VolunteerVision.Domain.Core.Abstractions;
using VolunteerVision.Domain.Resources.Users;

namespace VolunteerVision.Domain.Resources.Users.Specs;

public sealed class UserByEmailSpec : Spec<User>
{
    public UserByEmailSpec(string email) => Where(u => u.Email == email);
}
