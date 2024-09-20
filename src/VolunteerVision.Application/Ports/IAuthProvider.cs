using VolunteerVision.Application.Ports.Models;
using VolunteerVision.Domain.Core.Maybe;

namespace VolunteerVision.Application.Ports;

/// <summary>
/// Port for authenticating users.
/// </summary>
public interface IAuthProvider
{
    Task<Maybe<AuthModel>> AuthenticateAsync(string email, string password);
    Task<Maybe<AuthModel>> RefreshTokenAsync(string refreshToken);
    Task<Maybe<AuthModel>> RegisterAsync(
        string name,
        string email, 
        string password);
}