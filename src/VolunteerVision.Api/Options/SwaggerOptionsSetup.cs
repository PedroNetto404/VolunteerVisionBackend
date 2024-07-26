using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace VolunteerVision.Api.Options;

internal sealed class SwaggerOptionsSetup(
    IConfiguration config) : IConfigureNamedOptions<SwaggerGenOptions>
{
    public void Configure(SwaggerGenOptions options) => options.SwaggerDoc(
        config["Swagger:Version"],
        new OpenApiInfo
        {
            Title = config["Swagger:Title"],
            Version = config["Swagger:Version"],
            Description = config["Swagger:Description"],
            Contact = new()
            {
                Name = config["Swagger:Contact:Name"],
                Url = new(config["Swagger:Contact:Url"]!),
                Email = config["Swagger:Contact:Email"]
            }
        }
    );

    public void Configure(string? _, SwaggerGenOptions options) =>
        Configure(options);
}
