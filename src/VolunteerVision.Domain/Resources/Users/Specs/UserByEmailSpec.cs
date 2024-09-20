using Ardalis.Specification;
using VolunteerVision.Domain.Resources.Users.ValueObjects;

namespace VolunteerVision.Domain.Resources.Users.Specs;

public sealed class UserByEmailSpec : SingleResultSpecification<User>
{
    public UserByEmailSpec(Email email) =>
        Query.AsNoTracking()
             .Where(p => p.Email == email);
}
