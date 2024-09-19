using Ardalis.Specification;

namespace VolunteerVision.Domain.Resources.Users.Specs;

public sealed class UserByEmailSpec : SingleResultSpecification<User>
{
    public UserByEmailSpec(string email) =>
        Query.AsNoTracking()
             .Where(p => p.Email == email);
}
