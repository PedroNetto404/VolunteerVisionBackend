namespace VolunteerVision.Domain.Core.Abstractions;

public record AggregateRootDeleted(Guid AggregateId) : IDomainEvent;