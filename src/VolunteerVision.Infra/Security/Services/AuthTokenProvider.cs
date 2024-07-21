using VolunteerVision.Application.Ports;

namespace VolunteerVision.Infra.Security.Services;

internal class AuthTokenProvider : IAuthTokenProvider
{
    public IAuthTokenProvider.Token GenerateToken(string userId)
    {
        throw new NotImplementedException();
    }
}
