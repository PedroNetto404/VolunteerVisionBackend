using System.Collections.Concurrent;
using Microsoft.EntityFrameworkCore.Diagnostics;
using VolunteerVision.Domain.Core.Abstractions;

namespace VolunteerVision.Infra.Persistence.Interceptors;

public class DomainEventsInterceptor(
    ConcurrentQueue<IDomainEvent> toPublish
) : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData, 
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        eventData
            .Context!
            .ChangeTracker
            .Entries<IAggregateRoot>()
            .Select(p => p.Entity)
            .SelectMany(aggregate =>
            {
                var domainEvents = aggregate.DomainEvents;
                aggregate.ClearDomainEvents();
                return domainEvents;
            })
            .ToList()
            .ForEach(toPublish.Enqueue);

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
