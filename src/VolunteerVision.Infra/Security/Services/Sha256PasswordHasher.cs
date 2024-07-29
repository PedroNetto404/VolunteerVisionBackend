using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using VolunteerVision.Application.Ports;
using VolunteerVision.Domain.Core.Attributes;
using VolunteerVision.Domain.Ports;

namespace VolunteerVision.Infra.Security.Services;

[ScopedService]
internal class Sha256PasswordHasher : IPasswordHasher
{
    public string HashPassword(string password)
    {
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = SHA256.HashData(bytes);

        return Convert.ToBase64String(hash);
    }

    public bool VerifyHashedPassword(string hashedPassword, string password)
    {
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = SHA256.HashData(bytes);

        return hashedPassword == Convert.ToBase64String(hash);
    }
}
