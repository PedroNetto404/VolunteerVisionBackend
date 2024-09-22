using VolunteerVision.Domain.Core.Result;

namespace VolunteerVision.Domain.Errors;

public sealed partial class DomainError
{   
    public static class User
    {
        public static readonly Error NotFound = new("user", "user not found");
        public static readonly Error InvalidName = new("user", "");
        public static readonly Error  ValidRefreshTokenAlreadyExists = new("user", "");
        public static readonly Error AlreadyAuthenticated = new("user", "");
        public static readonly Error PasswordNotMatch = new("user", "");
        public static readonly Error AlreadyExists = new("user", "user alredy exists");
        public static readonly Error NotHavaRefreshToken = new("user", "user cannot refresh token");
        public static readonly Error ExpiredRefreshToken = new("user", "user has a expired refresh token");
        public static readonly Error RefreshTokenNotMatch = new("user", "informed refresh token not match with user token");
    }   
}
