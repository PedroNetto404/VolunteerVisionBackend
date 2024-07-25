using System.Collections.Concurrent;
using Microsoft.EntityFrameworkCore.Diagnostics;
using VolunteerVision.Domain.Core.Abstractions;

namespace VolunteerVision.Infra;

public class DomainEventsInterceptor(
    ConcurrentQueue<IDomainEvent> toPublish
) : SaveChangesInterceptor
{
    private readonly ConcurrentQueue<IDomainEvent> _toPublish = toPublish;

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData, 
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        eventData
            .Context!
            .ChangeTracker
            .Entries<AggregateRoot>()
            .Select(p => p.Entity)
            .SelectMany(aggregate =>
            {
                var domainEvents = aggregate.DomainEvents;
                aggregate.ClearDomainEvents();
                return domainEvents;
            })
            .ToList()
            .ForEach(_toPublish.Enqueue);

        return base.SavingChangesAsync(
            eventData, 
            result, 
            cancellationToken);
    }

    public override ValueTask<int> SavedChangesAsync(
        SaveChangesCompletedEventData eventData,
        int result,
        CancellationToken cancellationToken = default) => 
            base.SavedChangesAsync(
                eventData,
                result,
                cancellationToken);
}
