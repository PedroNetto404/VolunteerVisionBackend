using VolunteerVision.Domain.Resources.Users;
using VolunteerVision.Domain.Resources.Users.ValueObjects;

namespace VolunteerVision.Application;

public interface ITokenProvider
{
    (Token AccessToken, Token RefreshToken) GenerateTokens(User user);
}
