namespace VolunteerVision.Domain.Core.Abstractions;

/// <summary>
/// Interface representing an aggregate root in the domain.
/// </summary>
public interface IAggregateRoot : IEntity
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

    void ClearDomainEvents();

    void RaiseDomainEvent(IDomainEvent domainEvent);
}
