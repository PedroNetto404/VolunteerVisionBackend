namespace VolunteerVision.Domain.Ports;

/// <summary>
/// Port for hashing and verifying passwords.
/// </summary>
public interface IPasswordHasher
{
    bool VerifyHashedPassword(string hashedPassword, string password);
    string HashPassword(string password);
}
