using System.Collections.Concurrent;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VolunteerVision.Domain.Core.Abstractions;
using VolunteerVision.Infra.BackgroundServices;
using VolunteerVision.Infra.Persistence;

namespace VolunteerVision.Infra.Extensions;

public static partial class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration) =>
        services
            .AddHostedServices(configuration)
            .AddDatabase(configuration)
            .AddAuth(configuration);
}
