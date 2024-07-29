using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using VolunteerVision.Application;

namespace VolunteerVision.Infra;

internal sealed class JwtPayloadUserContextProvider(
    IHttpContextAccessor httpContextAccessor
) : IUserContextProvider
{
    private readonly ClaimsIdentity _identity = 
        httpContextAccessor?.HttpContext?.User.Identity as ClaimsIdentity ?? 
        throw new InvalidOperationException("User is not authenticated");

    public Guid UserId =>  Guid.Parse(_identity.FindFirst(ClaimTypes.NameIdentifier)!.Value);

    public bool IsAuthenticated => _identity.IsAuthenticated;

    public string Email => _identity.FindFirst(ClaimTypes.Email)!.Value;
}
