using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using VolunteerVision.Application;
using VolunteerVision.Application.Ports;
using VolunteerVision.Domain.Core.Attributes;

namespace VolunteerVision.Infra.Security.Services;

[ScopedService]
internal sealed class JwtPayloadUserContextProvider(
    IHttpContextAccessor httpContextAccessor
) : IUserContextProvider
{
    private readonly ClaimsIdentity _identity =
        httpContextAccessor?.HttpContext?.User.Identity as ClaimsIdentity ??
        throw new InvalidOperationException("User is not authenticated");

    public Guid UserId => Guid.Parse(_identity.FindFirst(ClaimTypes.NameIdentifier)!.Value);

    public bool IsAuthenticated => _identity.IsAuthenticated;

    public string Email => _identity.FindFirst(ClaimTypes.Email)!.Value;
}
