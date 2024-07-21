using VolunteerVision.Application.Ports;

namespace VolunteerVision.Infra.Security.Services;

internal class PasswordHasher : IPasswordHasher
{
    public string HashPassword(string password)
    {
        throw new NotImplementedException();
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        throw new NotImplementedException();
    }
}
