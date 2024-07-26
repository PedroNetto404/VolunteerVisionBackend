using System.Collections.Concurrent;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VolunteerVision.Domain.Core.Abstractions;
using VolunteerVision.Infra.BackgroundServices;

namespace VolunteerVision.Infra.Extensions;

public static partial class DependencyInjection
{
    private static IServiceCollection AddHostedServices(
        this IServiceCollection services,
        IConfiguration configuration) =>
        services
            .AddSingleton<DomainEventsDispatcher>()
            .AddSingleton<ConcurrentQueue<IDomainEvent>>()
            .AddHostedService<DomainEventsDispatcher>();
}
