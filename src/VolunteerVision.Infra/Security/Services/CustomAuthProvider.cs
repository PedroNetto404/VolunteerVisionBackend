using VolunteerVision.Application.Ports;
using VolunteerVision.Domain.Core.Attributes;
using VolunteerVision.Domain.Core.Result;
using VolunteerVision.Domain.Errors;
using VolunteerVision.Domain.Ports;
using VolunteerVision.Domain.Resources.Users;
using VolunteerVision.Domain.Resources.Users.Specs;
using VolunteerVision.Domain.Resources.Users.ValueObjects;

namespace VolunteerVision.Infra.Security.Services;

[ScopedService]
public sealed class CustomAuthProvider(
    ITokenGenerator tokenGenerator,
    IUserContextProvider userContext,
    IRepository<User> userRepository,
    IPasswordHasher passwordHasher
) : IAuthProvider
{
    public async Task<Result<AuthModel>> AuthenticateAsync(string email, string password)
    {
        if(userContext.IsAuthenticated)
        {
            return DomainError.User.AlreadyAuthenticated;
        }

        var maybeEmail = Email.New(email);
        if(maybeEmail.IsFail) 
        {
            return maybeEmail.Error;
        }

        var user = await userRepository.FirstOrDefaultAsync(new UserByEmailSpec(maybeEmail.Value));
        if(user is null)
        {
            return DomainError.User.NotFound;
        }

        if(!passwordHasher.Match(user.HashedPassword, password))
        {
            return DomainError.User.PasswordNotMatch;
        }

        var refreshToken = tokenGenerator.GenerateRefreshToken();
        user.SetRefreshToken(refreshToken);
        await userRepository.UpdateAsync(user);

        var accessToken = tokenGenerator.GenerateAccessTokenFor(user);
        return AuthModel.Create(accessToken, refreshToken);
    }

    public async Task<Result<AuthModel>> RefreshTokenAsync(string refreshToken)
    {
        if(!userContext.IsAuthenticated)
        {
            return new Error("auth", "Cannot refresh token from unauthenticated user");
        }

        var user = await userRepository.GetByIdAsync(userContext.UserId);
        if(user is null)
        {
            return DomainError.User.NotFound;
        }

        if(user.CanRefreshToken(refreshToken) is { IsFail: true, Error: var error})
        {
            return error;
        }

        var newAccessToken = tokenGenerator.GenerateAccessTokenFor(user);
        return AuthModel.Create(newAccessToken, user.RefreshToken!);
    }

    public async Task<Result<AuthModel>> RegisterAsync(string name, string email, string password)
    {
        if(userContext.IsAuthenticated)
        {
            return new Error("auth", "Cannot register a authenticated user");
        }

        var maybeEmail = Email.New(email);
        if(maybeEmail.IsFail)
        {
            return maybeEmail.Error;
        }

        var maybePassword = Password.New(password);
        if(maybePassword.IsFail)
        {
            return maybePassword.Error;
        }
        
        var existingUser = await userRepository.FirstOrDefaultAsync(new UserByEmailSpec(maybeEmail.Value));
        if(existingUser is not null)
        {
            return DomainError.User.AlreadyExists;
        }

        var maybeUser = User.CreateCommon(name, maybeEmail.Value, maybePassword.Value, passwordHasher);
        if(maybeUser is not { IsOk: true, Value: var user })
        {
            return maybeUser.Error;
        }
    
        var refreshToken = tokenGenerator.GenerateRefreshToken();
        user.SetRefreshToken(refreshToken);
        await userRepository.AddAsync(maybeUser);

        var accessToken = tokenGenerator.GenerateAccessTokenFor(user);
        return AuthModel.Create(accessToken, refreshToken);
    }
}
