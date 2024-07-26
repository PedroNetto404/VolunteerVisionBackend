using System.Collections.Concurrent;
using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using VolunteerVision.Domain.Core.Abstractions;

namespace VolunteerVision.Infra.BackgroundServices;

internal class DomainEventsDispatcher(
    ConcurrentQueue<IDomainEvent> domainEvents,
    IMediator mediator,
    ILogger<DomainEventsDispatcher> logger
) : BackgroundService
{
    private static readonly PeriodicTimer Timer = new(TimeSpan.FromSeconds(1));

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Timer.WaitForNextTickAsync(stoppingToken);

            while (domainEvents.TryDequeue(out var domainEvent))
            {
                try
                {
                    await mediator.Publish(domainEvent, stoppingToken);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Error occurred while handling domain event: {DomainEvent}", domainEvent);
                }
            }
        }
    }
}
