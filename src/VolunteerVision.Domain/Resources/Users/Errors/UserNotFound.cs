using VolunteerVision.Domain.Core.Error;
using VolunteerVision.Domain.Resources.Users;

namespace VolunteerVision.Domain;

public sealed record UserNotFound : DomainAggregateError<User, UserNotFound>
{
    public UserNotFound() : base("user", "User not found")
    {
    }
}