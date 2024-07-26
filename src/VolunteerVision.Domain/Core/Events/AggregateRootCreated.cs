namespace VolunteerVision.Domain.Core.Abstractions;

public record AggregateRootCreated(Guid AggregateId) : IDomainEvent;