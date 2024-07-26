using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using VolunteerVision.Domain.Core.Attributes;

namespace VolunteerVision.Domain.Core.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddMarkedServices(
        this IServiceCollection services) =>
        AppDomain
            .CurrentDomain
            .GetAssemblies()
            .SelectMany(p => p.GetTypes())
            .Select(p => new
            {
                ConcreteType = p,
                Abstractions = p.GetInterfaces(),
                ServiceLifetime = p.GetCustomAttribute<ServiceAttribute>()?.Lifetime
            })
            .Where(p => p.ServiceLifetime != null)
            .SelectMany(p => p.Abstractions.Select(
                q => new ServiceDescriptor(
                    q,
                    p.ConcreteType,
                    p.ServiceLifetime!.Value)))
            .Aggregate(services, (acc, p) =>
            {
                acc.Add(p);
                return acc;
            });
}
