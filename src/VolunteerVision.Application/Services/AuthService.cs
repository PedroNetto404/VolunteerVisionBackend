using VolunteerVision.Application.Ports;
using VolunteerVision.Application.Ports.Models;
using VolunteerVision.Domain;
using VolunteerVision.Domain.Core.Error;
using VolunteerVision.Domain.Ports;
using VolunteerVision.Domain.Resources.Users;
using VolunteerVision.Domain.Resources.Users.Specs;

namespace VolunteerVision.Application;

public sealed class AuthService(
    IUserContextProvider userContextProvider,
    IPasswordHasher passwordHasher,
    IUnitOfWork unitOfWork,
    ITokenProvider tokenProvider) : IAuthProvider
{
    public async Task<ErrorOr<AuthResponse>> AuthenticateAsync(string email, string password)
    {
        var user = await unitOfWork.Users.FirstOrDefaultAsync(new UserByEmailSpec(email));
        if (user is null)
        {
            return UserNotFound.Instance;
        }

        if (user.CanLogin(password, passwordHasher) is { IsFail: true, Error: var error })
        {
            return error;
        }

        return await GenTokensAndSaveState(user);
    }

    public async Task<ErrorOr<AuthResponse>> RefreshTokenAsync(string refreshToken)
    {
        var user = await unitOfWork.Users.GetByIdAsync(userContextProvider.UserId);
        if (user is null)
        {
            return UserNotFound.Instance;
        }

        if (user.CanRefreshToken(refreshToken) is { IsFail: true, Error: var error })
        {
            return error;
        }

        return await GenTokensAndSaveState(user);
    }

    public async Task<ErrorOr<AuthResponse>> RegisterAsync(
        string name,
        string email, 
        string password)
    {
        var user = User.Create(name, email, password, passwordHasher);
        if (user.IsFail)
        {
            return user.Error;
        }

        var tokens = tokenProvider.GenerateTokens(user.Value);
        user.Value.SetRefreshToken(tokens.RefreshToken);

        await unitOfWork.Users.AddAsync(user.Value);
        var saved = await unitOfWork.SaveChangesAsync();
        if (!saved)
        {
            return CannotSaveChanges.Instance;
        }

        return (AuthResponse)tokens;
    }

    private async Task<ErrorOr<AuthResponse>> GenTokensAndSaveState(User user)
    {
        var tokensTuple = tokenProvider.GenerateTokens(user);
        user.SetRefreshToken(tokensTuple.RefreshToken);

        await unitOfWork.Users.UpdateAsync(user);
        var saved = await unitOfWork.SaveChangesAsync();
        if (!saved)
        {
            return CannotSaveChanges.Instance;
        }

        return (AuthResponse)tokensTuple;
    }
}

