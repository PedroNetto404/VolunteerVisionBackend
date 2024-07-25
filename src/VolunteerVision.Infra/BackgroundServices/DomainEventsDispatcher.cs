using System.Collections.Concurrent;
using Microsoft.Extensions.Hosting;
using VolunteerVision.Domain.Core.Abstractions;

namespace VolunteerVision.Infra;

public class DomainEventsDispatcher(
    ConcurrentQueue<IDomainEvent> domainEvents,
    Mediator
) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {   
        while (!stoppingToken.IsCancellationRequested)
        {
            try {
                if (domainEvents.TryDequeue(out var domainEvent))
                {
                    // Dispatch domain event
                }
            } catch (Exception ex) {
                // Log exception
            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}
