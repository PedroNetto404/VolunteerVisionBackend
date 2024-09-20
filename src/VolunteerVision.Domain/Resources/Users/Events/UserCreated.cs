using VolunteerVision.Domain.Core.Abstractions;

namespace VolunteerVision.Domain.Resources.Users.Events;

public sealed record UserCreated(Guid UserId) : IDomainEvent;
