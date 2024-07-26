namespace VolunteerVision.Domain.Core.Abstractions;

public record AggregateRootUpdated(Guid AggregateId) : IDomainEvent;