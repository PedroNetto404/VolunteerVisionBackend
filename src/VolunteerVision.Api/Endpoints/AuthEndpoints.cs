using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using VolunteerVision.Application.Ports;
using VolunteerVision.Domain.Core.Result;
using PasswordVo = VolunteerVision.Domain.Resources.Users.ValueObjects.Password;

namespace VolunteerVision.Api.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("api/auth").WithDisplayName("Auth").WithOrder(1);

        group.MapPost("sign-in", SignInAsync)
             .Produces(StatusCodes.Status200OK, typeof(AuthModel))
             .Produces(StatusCodes.Status400BadRequest);

        group.MapPost("sign-up", SignUpAsync)
             .Produces(StatusCodes.Status200OK, typeof(AuthModel))
             .Produces(StatusCodes.Status400BadRequest);

        group.MapPost("refresh-token", RefreshTokenAsync)
             .Produces(StatusCodes.Status200OK, typeof(AuthModel))
             .Produces(StatusCodes.Status400BadRequest)
             .RequireAuthorization();
    }

    private static Task<IResult> SignInAsync
    (
        [FromServices] IAuthProvider authProvider, 
        [FromBody] SignInModel model
    ) =>
        authProvider.AuthenticateAsync(model.Email, model.Password)
                    .MatchAsync(Results.Ok, Results.BadRequest);

    private static Task<IResult> SignUpAsync
    (
        [FromServices] IAuthProvider authProvider,
        [FromBody] SignUpModel model
    ) =>
        authProvider.RegisterAsync(model.Name, model.Email, model.Password)
                    .MatchAsync(Results.Ok, Results.BadRequest);

    private static Task<IResult> RefreshTokenAsync(
        [FromServices] IAuthProvider authProvider,
        [FromBody] string refreshToken
    ) =>
        authProvider.RefreshTokenAsync(refreshToken)
                    .MatchAsync(Results.Ok, Results.BadRequest);
}

public sealed record SignInModel
{
    [Required]
    [EmailAddress]
    public required string Email {get; init;}

    [Required]
    [StringLength(PasswordVo.MaxLength, MinimumLength = PasswordVo.MinLength)]
    public required string Password {get; init;}
}

public sealed record SignUpModel
{
    [Required]
    [EmailAddress]
    public required string Email {get; init;}

    [Required]
    [StringLength(PasswordVo.MaxLength, MinimumLength = PasswordVo.MinLength)]
    public required string Password {get; init;}

    [Required]
    public required string Name {get; init;}
}
