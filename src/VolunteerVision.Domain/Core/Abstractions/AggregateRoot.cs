

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

public abstract class AuditableAggregateRoot : AggregateRoot, IAuditableEntity
{
    public DateTime CreatedAtUtc { get; private set; } = DateTime.UtcNow;

    public DateTime UpdatedAtUtc { get; private set; } = DateTime.UtcNow;

    public DateTime? DeletedAtUtc { get; private set; }

    protected void OnUpdated() => UpdatedAtUtc = DateTime.UtcNow;
    protected void OnDeleted() => DeletedAtUtc = DateTime.UtcNow;
}