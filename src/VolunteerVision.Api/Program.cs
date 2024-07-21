using VolunteerVision.Api;
using VolunteerVision.Application;
using VolunteerVision.Infra;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddPresentation(builder.Configuration)
    .AddInfrastructure(builder.Configuration)
    .AddApplication(builder.Configuration);

var app = builder.Build();

app.ApplyMigrations();
app.ConfigurePipeline(builder.Environment);

await app.RunAsync();
