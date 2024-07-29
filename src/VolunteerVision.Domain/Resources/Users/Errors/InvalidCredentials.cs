using VolunteerVision.Domain.Core.Error;
using VolunteerVision.Domain.Resources.Users;

namespace VolunteerVision.Domain;

public sealed record class InvalidCredentials : DomainAggregateError<User, InvalidCredentials>
{
    public InvalidCredentials() : base("invalid_password", "Invalid password")
    {
    }
}
