using VolunteerVision.Domain.Core.Error;

namespace VolunteerVision.Domain.Resources.Users.Errors;

public sealed record TokenExpired : DomainAggregateError<User, TokenExpired>
{
    public TokenExpired() : base("auth", "Token expired")
    {
    }
}
