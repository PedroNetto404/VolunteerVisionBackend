using System.ComponentModel.DataAnnotations.Schema;
using VolunteerVision.Domain.Core.Abstractions;
using VolunteerVision.Domain.Core.Maybe;
using VolunteerVision.Domain.Errors;
using VolunteerVision.Domain.Ports;
using VolunteerVision.Domain.Resources.Users.Enums;
using VolunteerVision.Domain.Resources.Users.Events;
using VolunteerVision.Domain.Resources.Users.ValueObjects;

namespace VolunteerVision.Domain.Resources.Users;

public sealed class User : AuditableAggregateRoot
{
    public string Name { get; private set; }
    public Email Email { get; private set; }
    public string HashedPassword { get; private set; }
    public Role Role { get; private set; }
    public Token? RefreshToken { get; private set; }

    private User
    (
        string name,
        Email email,
        string hashedPassword,
        Role role
    )
    {
        Name = name;
        Email = email;
        HashedPassword = hashedPassword;
        Role = role;
    }

    public static Maybe<User> CreateCommon(
        string name,
        Email email,
        Password password,
        IPasswordHasher passwordHasher)
    {
        if (string.IsNullOrEmpty(name))
        {
            return DomainErrors.Users.InvalidName;
        }

        var user = new User
        (
            name,
            email,
            passwordHasher.HashPassword(password.Value),
            Role.Common
        );

        user.RaiseDomainEvent(new UserCreated(user.Id));

        return user;
    }

    public Maybe SetRefreshToken(Token refreshToken)
    {
        if (RefreshToken is { Expired: false })
        {
            return DomainErrors.Users.RefreshTokenAlreadySetted;
        }

        RefreshToken = refreshToken;
        return Maybe.Ok();
    }
    
    public bool CanRefreshToken => RefreshToken is { Expired: false };

#pragma warning disable CS0628 // New protected member declared in sealed type
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    /// <summary>
    /// EF Core constructor
    /// </summary>
    protected User() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning restore CS0628 // New protected member declared in sealed type
}
