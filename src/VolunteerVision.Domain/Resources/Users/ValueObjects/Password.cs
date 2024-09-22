using System.Text.RegularExpressions;
using VolunteerVision.Domain.Core.Result;

namespace VolunteerVision.Domain.Resources.Users.ValueObjects;

public sealed partial record Password
{
    public const int MaxLength = 16;
    public const int MinLength = 8;
    public string Value {get;}
    private Password(string value) => Value = value;

    public static Result<Password> New(string value)
    {
        if(string.IsNullOrWhiteSpace(value))
        {
            return new Error("password", "Password cannot be null or empty");
        }

        if(!Regex().IsMatch(value))
        {
            return new Error("password", "Password must be 8-16 characters long, include at least one uppercase letter, one lowercase letter, one number, and one special character");
        }

        return new Password(value);
    }

    [GeneratedRegex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,16}$")]
    private static partial Regex Regex();
}
