namespace VolunteerVision.Application.Ports;

/// <summary>
/// Interface for hashing and verifying passwords.
/// </summary>
public interface IPasswordHasher
{
    string HashPassword(string password);
    bool VerifyPassword(string password, string hashedPassword);
}
