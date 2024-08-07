﻿namespace VolunteerVision.Infra.Security.Options;

/// <summary>
/// Options for JWT authentication.
/// </summary>
internal record class JwtOptions
{
    public const string SectionName = "Jwt";

    public required string Secret { get; init; }
    public required string Issuer { get; init; }
    public required string Audience { get; init; }
    public required int AccessTokenExpirationInMinutes { get; init; }
    public required int RefreshTokenExpirationInMinutes { get; init; }
}
