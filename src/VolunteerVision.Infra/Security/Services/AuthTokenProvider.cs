using VolunteerVision.Application.Ports;
using VolunteerVision.Domain.Core.Attributes;

namespace VolunteerVision.Infra.Security.Services;

[ScopedService]
internal class AuthTokenProvider : IAuthTokenProvider
{
    public IAuthTokenProvider.Token GenerateToken(string userId)
    {
        throw new NotImplementedException();
    }
}
