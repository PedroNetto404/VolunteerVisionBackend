using MediatR;
using VolunteerVision.Domain.Core.Abstractions;
using VolunteerVision.Domain.Core.Error;
using VolunteerVision.Domain.Ports;
using VolunteerVision.Domain.Resources.Users.ValueObjects;

namespace VolunteerVision.Domain.Resources.Users;

public sealed class User : AggregateRoot
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string HashedPassword { get; private set; }
    public Role Role { get; private set; }
    public Token? RefreshToken { get; private set; }

    private User(
        string name,
        string email,
        string hashedPassword)
    {
        Name = name;
        Email = email;
        HashedPassword = hashedPassword;
        Role = Role.CommonUser;
    }

    public static ErrorOr<User> Create(
        string name,
        string email,
        string password,
        IPasswordHasher passwordHasher)
    {
        var hashedPassword = passwordHasher.HashPassword(password);
        var user = new User(
            name,
            email,
            hashedPassword
        );

        user.RaiseDomainEvent(new UserCreated(user.Id));

        return user;
    }

    public ErrorOr<Unit> CanLogin(string password, IPasswordHasher passwordHasher) =>
        passwordHasher.VerifyHashedPassword(HashedPassword, password)
            ? Unit.Value
            : InvalidCredentials.Instance;

    public ErrorOr<Unit> SetRefreshToken(Token refreshToken)
    {
        if (RefreshToken is { IsExpired: false })
        {
            return RefreshTokenNotExpired.Instance;
        }

        if (refreshToken.IsExpired)
        {
            return RefreshTokenExpired.Instance;
        }

        RefreshToken = refreshToken;

        return Unit.Value;
    }

    public ErrorOr<Unit> CanRefreshToken(string refreshToken) =>
        RefreshToken is { IsExpired: false, Value: var value }
            ? value == refreshToken
                ? Unit.Value
                : InvalidRefreshToken.Instance
            : RefreshTokenExpired.Instance;

#pragma warning disable CS0628 // New protected member declared in sealed type


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    /// <summary>
    /// EF Core constructor
    /// </summary>
    protected User() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning restore CS0628 // New protected member declared in sealed type
}