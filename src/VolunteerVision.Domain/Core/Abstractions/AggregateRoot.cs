namespace VolunteerVision.Domain.Core.Abstractions;

public abstract class AggregateRoot : Entity, IAggregateRoot
{
    private readonly List<IDomainEvent> _domainEvents = [];
   
    public IReadOnlyCollection<IDomainEvent> DomainEvents => 
        _domainEvents.ToList()
                     .AsReadOnly();

    public void ClearDomainEvents() =>
        _domainEvents.Clear();

    public void RaiseDomainEvent(
        IDomainEvent domainEvent) =>
        _domainEvents.Add(domainEvent);
}