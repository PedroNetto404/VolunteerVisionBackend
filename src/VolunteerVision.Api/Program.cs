using VolunteerVision.Api;
using VolunteerVision.Api.Extensions;
using VolunteerVision.Application;
using VolunteerVision.Domain.Extensions;
using VolunteerVision.Infra.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddPresentation(builder.Configuration)
    .AddDomain()
    .AddInfrastructure(builder.Configuration)
    .AddApplication(builder.Configuration);

await builder
    .Build()
    .ApplyMigrations()
    .AddSeedIfDevelopment()
    .UsePipeline()
    .RunAsync();
