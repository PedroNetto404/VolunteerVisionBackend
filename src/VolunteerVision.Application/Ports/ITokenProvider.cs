using VolunteerVision.Application.Ports.Models;
using VolunteerVision.Domain.Resources.Users;

namespace VolunteerVision.Application;

public interface ITokenProvider
{
    (Token AccessToken, Token RefreshToken) GenerateTokens(User user);
}
