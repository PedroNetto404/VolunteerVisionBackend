using VolunteerVision.Application.Ports.Models;
using VolunteerVision.Domain.Core.Error;

namespace VolunteerVision.Application.Ports;

/// <summary>
/// Port for authenticating users.
/// </summary>
public interface IAuthProvider
{
    Task<ErrorOr<AuthResponse>> AuthenticateAsync(string email, string password);
    Task<ErrorOr<AuthResponse>> RefreshTokenAsync(string refreshToken);
    Task<ErrorOr<AuthResponse>> RegisterAsync(
        string name,
        string email, 
        string password);
}