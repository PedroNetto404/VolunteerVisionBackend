using VolunteerVision.Api.Extensions;
using VolunteerVision.Application.Extensions;
using VolunteerVision.Domain.Core.Extensions;
using VolunteerVision.Domain.Extensions;
using VolunteerVision.Infra.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddMarkedServices()
    .AddPresentation()
    .AddDomain()
    .AddInfrastructure(builder.Configuration)
    .AddApplication();

var app = builder.Build();

await app.ApplyMigrations();
await Task.WhenAll(
    app.UsePipeline().RunAsync(),
    app.AddSeedDatabaseIfDevelopmentAsync());
