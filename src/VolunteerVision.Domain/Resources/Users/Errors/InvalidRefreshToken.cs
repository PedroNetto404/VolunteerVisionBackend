using VolunteerVision.Domain.Core.Error;
using VolunteerVision.Domain.Resources.Users;

namespace VolunteerVision.Domain;

public sealed record InvalidRefreshToken : DomainAggregateError<User, InvalidRefreshToken>
{
    public InvalidRefreshToken() : base("auth", "Invalid refresh token")
    {
    }
}
