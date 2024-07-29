using VolunteerVision.Domain.Core.Error;
using VolunteerVision.Domain.Resources.Users;

namespace VolunteerVision.Domain;

public sealed record RefreshTokenNotExpired : DomainAggregateError<User, RefreshTokenNotExpired>
{
    public RefreshTokenNotExpired() : base("auth", "Refresh token not expired")
    {
    }
}
