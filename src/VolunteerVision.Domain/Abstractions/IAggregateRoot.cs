namespace VolunteerVision.Domain.Abstractions;

/// <summary>
/// Interface representing an aggregate root in the domain.
/// </summary>
public interface IAggregateRoot
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

    void ClearDomainEvents();

    void RaiseDomainEvent(IDomainEvent domainEvent);
}
