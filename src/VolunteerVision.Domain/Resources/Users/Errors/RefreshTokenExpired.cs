using VolunteerVision.Domain.Core.Error;
using VolunteerVision.Domain.Resources.Users;

namespace VolunteerVision.Domain;

public sealed record class RefreshTokenExpired : DomainAggregateError<User, RefreshTokenExpired>
{
    public RefreshTokenExpired() : base("auth", "Refresh token expired")
    {
    }
}
