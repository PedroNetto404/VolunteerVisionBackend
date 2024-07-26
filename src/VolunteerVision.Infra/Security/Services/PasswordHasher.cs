using Microsoft.Extensions.Options;
using VolunteerVision.Application.Ports;
using VolunteerVision.Domain.Core.Attributes;

namespace VolunteerVision.Infra.Security.Services;

[ScopedService]
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
