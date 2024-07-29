using VolunteerVision.Domain.Core.Abstractions;

namespace VolunteerVision.Domain;

public sealed record UserCreated(Guid UserId) : IDomainEvent;
