namespace VolunteerVision.Domain.Core.Abstractions;

public interface IAuditableEntity : IEntity
{
    public DateTime CreatedAt { get; protected set; } 
    public DateTime UpdatedAt { get; protected set; }
    public DateTime? DeletedAt { get; protected set; }
    
    public void OnUpdate()
    {
        UpdatedAt = DateTime.UtcNow;

        RaiseDomainEventIfAggregateRoot(
            () => new AggregateRootUpdated(Id));
    }
    
    public void OnCreate()
    {
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        
        RaiseDomainEventIfAggregateRoot(
            () => new AggregateRootCreated(Id));
    }
    
    public void OnDelete()
    {
        DeletedAt = DateTime.UtcNow;
        
        RaiseDomainEventIfAggregateRoot(
            () => new AggregateRootDeleted(Id));
    }
    
    private void RaiseDomainEventIfAggregateRoot(
        Func<IDomainEvent> domainEventFactory)
    {
        if(IsAggregateRoot(out var aggregateRoot))
        {
            aggregateRoot.RaiseDomainEvent(domainEventFactory());
        }
    }

    private bool IsAggregateRoot(out IAggregateRoot aggregateRoot)
    {
        if(GetType().IsAssignableTo(typeof(IAggregateRoot)))
        {
            // ReSharper disable once SuspiciousTypeConversion.Global
            aggregateRoot = (IAggregateRoot)this;
            return true;
        }
        
        aggregateRoot = default!;
        return false;
    }
}
