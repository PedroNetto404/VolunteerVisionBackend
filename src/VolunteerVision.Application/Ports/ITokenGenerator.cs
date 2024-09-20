using VolunteerVision.Application.Ports.Models;
using VolunteerVision.Domain.Resources.Users;
using VolunteerVision.Domain.Resources.Users.ValueObjects;

namespace VolunteerVision.Application.Ports;

public interface ITokenGenerator
{
    Token GenerateAccessTokenFor(User user);
    Token GenerateRefreshToken();
}
