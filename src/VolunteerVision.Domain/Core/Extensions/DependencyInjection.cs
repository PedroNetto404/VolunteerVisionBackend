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
                ServiceAttribute = p.GetCustomAttribute<ServiceAttribute>()
            })
            .Where(p => p.ServiceAttribute != null)
            .SelectMany(p => p.Abstractions.Select(
                q => new ServiceDescriptor(
                    serviceKey: (p.ServiceAttribute as KeyedServiceAttribute)?.Key,
                    serviceType: q,
                    implementationType: p.ConcreteType,
                    lifetime: p.ServiceAttribute!.Lifetime)))
            .Aggregate(services, (services, current) =>
            {
                services.Add(current);
                return services;
            });
}
